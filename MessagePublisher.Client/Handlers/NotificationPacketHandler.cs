using MessagePublisher.Packets;
using MessagePublisher.SignalR.Client.Handlers;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Handlers
{
    public class NotificationPacketHandler : PacketHandlerBase<NotificationPacket>
    {
        public NotificationPacketHandler()
        {

        }

        public override async Task Handle(NotificationPacket packet, HubConnection connection)
        {                  
            await Visualization.Instance?.PopupService?.ShowNotification(packet);
            //add confirmation??
        }
    }

}
