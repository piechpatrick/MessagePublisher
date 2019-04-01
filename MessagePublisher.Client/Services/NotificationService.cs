using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePublisher.Packets;
using Microsoft.AspNetCore.SignalR.Client;

namespace MessagePublisher.Client.Services
{
    public class NotificationService : INotificationService
    {
        private readonly string url = "http://localhost:58995/notificationsHub";
        public async Task Send(NotificationPacket notificationPacekt)
        {
            try
            {
                var connection = new HubConnectionBuilder()
                       .WithUrl(this.url)
                       .Build();
                await connection.StartAsync();
                await connection.InvokeAsync("SendToAll", notificationPacekt);
                await connection.DisposeAsync();
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
