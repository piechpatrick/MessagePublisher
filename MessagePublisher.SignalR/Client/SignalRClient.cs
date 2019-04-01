using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using MessagePublisher.SignalR.Client;
using MessagePublisher.SignalR.Client.Controllers;
using MessagePublisher.SignalR.Client.Modules;
using MessagesPublisher.Abstractions.Bindable;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace MessagePublisher.SignalR
{
    public class SignalRClient : BindableBase, ISignalRClient
    {
        private readonly IHubModulesController hubModulesController;
        private readonly ILogger<ISignalRClient> logger;

        private ObservableCollection<IHubModule> activeModules;
        public SignalRClient(IHubModulesController hubModulesController, ILogger<ISignalRClient> logger)
        {
            this.hubModulesController = hubModulesController;
            this.logger = logger;
            this.ActiveModules = new ObservableCollection<IHubModule>();
        }

        public ObservableCollection<IHubModule> ActiveModules
        {
            get { return this.activeModules; }
            set { this.SetProperty(ref this.activeModules, value); }
        }


        public async Task Start()
        {
            try
            {
                foreach (var module in this.hubModulesController.GetModules())
                {            
                    (module as BindableBase).PropertyChanged -= SignalRClient_PropertyChanged1;
                    (module as BindableBase).PropertyChanged += SignalRClient_PropertyChanged1;
                    await module.Connect();
                }
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, nameof(SignalRClient));
                throw;
            }
        }



        /// <summary>
        /// this begininvoke is about DX 17.2 bug with binding datasource
        /// </summary>
        private static readonly object syncRoot = new object();
        private void SignalRClient_PropertyChanged1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lock (syncRoot)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                {
                    if (e.PropertyName == "IsConnected")
                    {
                        if (this.ActiveModules.Contains((sender as IHubModule)))
                        {
                            if (!(sender as IHubModule).IsConnected)
                                this.ActiveModules.Remove((sender as IHubModule));
                        }
                        else
                        {
                            if ((sender as IHubModule).IsConnected)
                                this.ActiveModules.Add((sender as IHubModule));
                        }
                    }
                }));
            
            }
        }
    }
}
