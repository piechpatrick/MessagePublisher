using MessagePublisher.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagePublisher.Client.Forms
{
    public partial class NotificationForm : Form
    {
        Timer timer;
        public NotificationForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.checkConfirmation.Visible = false;
        }
        public NotificationForm(NotificationPacket notificationPacket, Image image)
            :this()
        {
            this.NotificationPacket = notificationPacket;
            this.richTextBox1.Text = this.NotificationPacket.Notification.Message;
            if (image != null)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Image = image;
                this.pictureBox1.Refresh();
            }
            else
                this.pictureBox1.Visible = false;
            this.Setup();           
        }

        private void Setup()
        {
            if (this.NotificationPacket.Notification.HasToConfirm)
            {
                this.checkConfirmation.Visible = true;
                this.btnConfirm.Visible = false;
            }
            if (this.NotificationPacket.Notification.CloseAfter > 0 && !this.NotificationPacket.Notification.HasToConfirm)
                this.SetTimer(this.NotificationPacket.Notification.CloseAfter);
        }

        private void SetTimer(int sec)
        {
            timer = new Timer();
            timer.Interval = sec * 1000; 
            timer.Start();
            timer.Tick += new EventHandler(Timer_Tick);
        }
        private void Timer_Tick(object sender, EventArgs eArgs)
        {
            timer.Stop();
            timer.Dispose();
            this.DialogResult = DialogResult.OK;
        }

        public NotificationPacket NotificationPacket { get; private set; }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void checkConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
                this.btnConfirm.Visible = true;
            else
                this.btnConfirm.Visible = false;
        }
    }
}
