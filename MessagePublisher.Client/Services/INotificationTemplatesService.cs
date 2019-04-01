using MessagePublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Services
{
    public interface INotificationTemplatesService
    {
        IEnumerable<NotificationTemplate> GetAll();
        void Add(NotificationTemplate notificationTemplate);
        void Update(NotificationTemplate notificationTemplate);
        void Remove(NotificationTemplate notificationTemplate);
    }
}
