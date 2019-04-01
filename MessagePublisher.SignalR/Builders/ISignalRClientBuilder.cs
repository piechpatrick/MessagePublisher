using MessagePublisher.SignalR.Client;
using MessagePublisher.SignalR.Client.Modules;
using MessagesPublisher.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.SignalR.Builders
{
    public interface ISignalRClientBuilder : IBuilder<ISignalRClientBuilder, ISignalRClient>
    {
        ISignalRClientBuilder AddHubModule<T>()
         where T : IHubModule;
    }
}
