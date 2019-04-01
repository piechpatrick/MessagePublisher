using MessagePublisher.Packets;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.SignalR.Client.Handlers
{

    public abstract class PacketHandlerBase<T> : IPacketHandler
    {
        public void Attach(HubConnection connection)
        {
            Task.Factory.StartNew(() =>
            {
                connection.On<T>(typeof(T).Name, (T) =>
                {
                    this.Handle(T, connection);
                });
            });
        }
        public abstract Task Handle(T packet, HubConnection connection);
    }

    public interface IPacketHandler
    {
        void Attach(HubConnection connection);
    }
}
