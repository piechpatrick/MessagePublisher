using MessagePublisher.SignalR.Client.Handlers;
using MessagesPublisher.Abstractions.Bindable;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.SignalR.Client.Modules
{
    public abstract class HubModuleBase : BindableBase, IHubModule
    {
        private readonly List<IPacketHandler> _packetHandlers = new List<IPacketHandler>();
        private HubConnection hubConnection;

        private bool isConnected;

        public HubModuleBase()
        {
           
        }

        public abstract string Url { get; }

        public bool IsConnected
        {
            get { return this.isConnected; }
            set { this.SetProperty(ref this.isConnected, value, "IsConnected"); }
        }

        public void AddPacketHandler<PacketHandler>()
            where PacketHandler : IPacketHandler
        {
            this._packetHandlers.Add(Activator.CreateInstance<PacketHandler>());
        }

        public IList<IPacketHandler> GetPacketHandlers()
        {
            return this._packetHandlers;
        }

        public HubConnection GetConnection()
        {
            if(this.hubConnection == null 
                || this.hubConnection.State == HubConnectionState.Disconnected)
            {
                this.hubConnection = new HubConnectionBuilder()
                   .WithUrl(this.Url)
                   .Build();
            }
            return this.hubConnection;
        }

        public async Task<IHubModule> Connect()
        {
            try
            {
                if (this.GetConnection().State == HubConnectionState.Connected)
                    await this.GetConnection().DisposeAsync();
                await this.GetConnection().StartAsync();
                this.GetConnection().Closed += HubModuleBase_Closed;
                foreach (var ph in this.GetPacketHandlers())              
                    ph.Attach(this.hubConnection);
                this.IsConnected = true;
            }
            catch(HttpRequestException httpEx)
            {
                //temp logging 
                Console.WriteLine(httpEx.StackTrace.ToString());
                this.IsConnected = false;
            } 
            catch(Exception ex)
            {
                this.IsConnected = false;
            }
            return this;
        }

        private Task HubModuleBase_Closed(Exception arg)
        {
            this.IsConnected = false;
            throw new Exception("Connection closed!");
        }
    }
}
