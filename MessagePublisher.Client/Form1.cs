using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using MessagePublisher.Client.Controls;
using MessagePublisher.Client.Extensions;
using MessagePublisher.Client.Services;
using MessagePublisher.Models;
using MessagePublisher.Packets;
using MessagePublisher.SignalR;
using MessagePublisher.SignalR.Client;
using MessagePublisher.SignalR.Client.Controllers;
using MessagesPublisher.Abstractions.Bindable;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace MessagePublisher.Client
{
    public partial class Form1 :  BaseForm, IPopupService, IUpdatable<UpdateNotificationTemplatesPacket>
    {




        private readonly INotificationTemplatesService notificationTemplatesService;
        private readonly INotificationService notificationService;
        private readonly IIconsService iconsService;
        private readonly ILogger<Form1> logger;
        public Form1(ISignalRClient signalRClient, 
            INotificationTemplatesService notificationTemplatesService,
            INotificationService notificationService,
            IIconsService iconsService,
            ILogger<Form1> logger)
        {
            InitializeComponent();
            this.SignalRClient = signalRClient;
            this.notificationTemplatesService = notificationTemplatesService;
            this.notificationService = notificationService;
            this.iconsService = iconsService;
            this.logger = logger;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.NotificationTemplates = new ObservableCollection<NotificationTemplate>();
            this.gridControl2.DataSource = this.NotificationTemplates;
            this.Images = new List<Image>();

            this.gridView2.Columns.Add(new GridColumn() { Visible = true, FieldName = "ImageIndex" });
        }

        public ISignalRClient SignalRClient { get; set; }

        private ObservableCollection<NotificationTemplate> NotificationTemplates { get; set; }

        public List<Image> Images { get; set; }

        public async Task<bool> ShowNotification(NotificationPacket notificationPacket)
        {
            return await this.ShowDialogAsync(notificationPacket, this.Images[notificationPacket.Notification.ImageIndex]);
        }

        public async Task Update(UpdateNotificationTemplatesPacket updateNotificationTemplatesPacket)
        {
            this.gridControl2.BeginInvoke(new Action(() =>
            {
                try
                {
                    foreach (var added in updateNotificationTemplatesPacket.Added)
                    {
                        this.NotificationTemplates.Add(added);
                    }
                    foreach (var removed in updateNotificationTemplatesPacket.Removed)
                    {
                        var toRemove = this.NotificationTemplates.Where(n => n.Guid == removed.Guid).FirstOrDefault();
                        if (toRemove != null)
                        {
                            this.NotificationTemplates.Remove(toRemove);
                        }
                    }
                    foreach (var updated in updateNotificationTemplatesPacket.Updated)
                    {
                        var toUpdate = this.NotificationTemplates.Where(n => n.Guid == updated.Guid).FirstOrDefault();
                        toUpdate.Name = updated.Name;
                        toUpdate.Message = updated.Message;
                        toUpdate.IsFavorite = updated.IsFavorite;
                        toUpdate.HasToConfirm = updated.HasToConfirm;
                        toUpdate.CloseAfter = updated.CloseAfter;
                        toUpdate.ImageIndex = updated.ImageIndex;
                    }
                    this.gridControl2.RefreshDataSource();
                    this.UpdateFavorite();
                }
                catch(Exception ex)
                {
                    this.logger.LogError(ex, nameof(Form1));
                }
            }));
        }

        private void RefreshData()
        {
            this.gridControl2.DataSource = this.NotificationTemplates = new ObservableCollection<NotificationTemplate>(this.notificationTemplatesService.GetAll());
            foreach (var template in this.NotificationTemplates)
            {
                (template as BindableBase).PropertyChanged += Form1_PropertyChanged;
            }
            this.gridControl1.DataSource = this.SignalRClient.ActiveModules;
            this.gridView1.BestFitColumns();
            this.UpdateFavorite();
        }

        private void UpdateFavorite()
        {
            this.toolStripDropDownButton1.DropDownItems.Clear();
            foreach (var fav in this.NotificationTemplates.Where(t => t.IsFavorite))
            {
                var toolStrip = this.toolStripDropDownButton1.DropDownItems.Add(fav.Name);
                new NotificationTemplateDropDownItemAdapter(toolStrip,fav,this.notificationService);
                this.toolStripDropDownButton1.DropDownItems.Add(toolStrip);
            }
            this.toolStrip1.Refresh();
        }

        private void Form1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.notificationTemplatesService.Update(sender as NotificationTemplate);
        }


        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (this.LoadingOn())
            {
                try
                {
                    await this.SignalRClient.Start();
                    this.RefreshData();
                    this.AttachImages();
                }
                catch (NullReferenceException nullRef)
                {
                    MessageBox.Show(nullRef.StackTrace.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }

        private void AttachImages()
        {
            this.Images = this.iconsService.GetAll().ToList();

            RepositoryItemImageComboBox imagesEditor = new RepositoryItemImageComboBox();

            DevExpress.Utils.ImageCollection imageCollection = new DevExpress.Utils.ImageCollection();
            foreach (var image in this.Images)
            {
                imageCollection.AddImage(image);
            }
            for (int i = 0; i < imageCollection.Images.Count; i++)
            {
                imagesEditor.Items.Add(new ImageComboBoxItem(i) { Description = $"{i}" });
            }
            imagesEditor.SmallImages = imageCollection;
            this.gridView2.Columns.Last().ColumnEdit = imagesEditor;
            this.gridControl2.Refresh();
            this.gridControl2.RefreshDataSource();
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            this.notificationTemplatesService.Add(new Models.NotificationTemplate());
        }

        private void btnDeleteTempalte_Click(object sender, EventArgs e)
        {

            var toDelte = this.NotificationTemplates.ElementAt(this.gridView2.GetSelectedRows().FirstOrDefault());
            if(toDelte != null)
                this.notificationTemplatesService.Remove(toDelte);
        }

        private void simpleButtonSend_Click(object sender, EventArgs e)
        {
            var selectedTempalte = this.NotificationTemplates.ElementAt(this.gridView2.GetSelectedRows().FirstOrDefault());
            if(selectedTempalte != null)
                this.notificationService.Send(new NotificationPacket() { Notification = selectedTempalte });

        }
    }
}

public interface IPopupService
{
    Task<bool> ShowNotification(NotificationPacket notificationPacket);
}
public interface IUpdatable<T>
{
    Task Update(T item);
}

public class NotificationTemplateDropDownItemAdapter 
{
    private readonly INotificationService notificationService;
    public NotificationTemplate NotificationTemplate { get; private set; }
    public NotificationTemplateDropDownItemAdapter(ToolStripItem toolStripItem, 
        NotificationTemplate notificationTemplate,
        INotificationService notificationService)
        : base()
    {
        this.NotificationTemplate = notificationTemplate;
        this.notificationService = notificationService;
        toolStripItem.Click += NotificationTemplateDropDownItemAdapter_Click;
    }

    public override string ToString()
    {
        return this.NotificationTemplate.Name;
    }
    private void NotificationTemplateDropDownItemAdapter_Click(object sender, EventArgs e)
    {
        this.notificationService.Send(new NotificationPacket() { Notification = this.NotificationTemplate });
    }
}

