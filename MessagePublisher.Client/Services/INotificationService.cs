using MessagePublisher.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Services
{
    public interface INotificationService
    {
        Task Send(NotificationPacket notificationPacekt);
    }
}
