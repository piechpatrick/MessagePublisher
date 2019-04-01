using MessagePublisher.Gateway.API.Repositories;
using MessagePublisher.Packets;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagePublisher.Gateway.API.Hubs
{
    public class NotificationsHub : Hub
    {
        public NotificationsHub()
        {

        }
        
        public async Task SendToAll(NotificationPacket notificationPacket)
        {
            await Clients.All.SendAsync(typeof(NotificationPacket).Name, notificationPacket);
        }

        public async Task Update(UpdateNotificationTemplatesPacket tempaltes)
        {
            await Clients.All.SendAsync(typeof(UpdateNotificationTemplatesPacket).Name, tempaltes);
        }


    }
}
