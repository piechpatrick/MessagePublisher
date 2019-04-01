using MessagePublisher.Client.Services;
using MessagePublisher.Common.Repositories;
using MessagePublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Repositories
{
    public class NotificationTemplatesRepository : INotificationTemplatesRepository
    {
        private readonly INotificationTemplatesService notificationTemplatesService;
        public NotificationTemplatesRepository(INotificationTemplatesService notificationTemplatesService)
        {
            this.notificationTemplatesService = notificationTemplatesService;
        }
        public NotificationTemplate Get(NotificationTemplate id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotificationTemplate> GetAll(Func<NotificationTemplate, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotificationTemplate> GetAll()
        {
            throw new NotImplementedException();
        }

        public void TryAdd(NotificationTemplate item)
        {
            throw new NotImplementedException();
        }

        public void TryAdd(IEnumerable<NotificationTemplate> items)
        {
            throw new NotImplementedException();
        }

        public void TryRemove(NotificationTemplate item)
        {
            throw new NotImplementedException();
        }

        public void TryRemove(IEnumerable<NotificationTemplate> items)
        {
            throw new NotImplementedException();
        }

        public void TrySet(IEnumerable<NotificationTemplate> items)
        {
            throw new NotImplementedException();
        }

        public void TrySet(NotificationTemplate item)
        {
            throw new NotImplementedException();
        }
    }
}
