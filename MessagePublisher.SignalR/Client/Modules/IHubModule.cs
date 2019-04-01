using MessagePublisher.SignalR.Client.Handlers;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.SignalR.Client.Modules
{
    public interface IHubModule
    {
        string Url { get; }
        bool IsConnected { get; }
        IList<IPacketHandler> GetPacketHandlers();
        HubConnection GetConnection();
        Task<IHubModule> Connect();
    }
}
