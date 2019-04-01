using MessagePublisher.Packets;
using MessagePublisher.SignalR.Client.Handlers;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MessagePublisher.Client.Handlers
{
    public class UpdateNotificationTemplatesPacketHandler : PacketHandlerBase<UpdateNotificationTemplatesPacket>
    {
        public override async Task Handle(UpdateNotificationTemplatesPacket packet, HubConnection connection)
        {
            await Visualization.Instance?.NotificationTemplatesUpdater.Update(packet);    
        }
    }
}
