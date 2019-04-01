using MessagePublisher.Models;
using MessagesPublisher.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Common.Repositories
{
    public interface INotificationTemplatesRepository : IRepository<NotificationTemplate>
    {
        void TrySet(NotificationTemplate item);
    }
}
