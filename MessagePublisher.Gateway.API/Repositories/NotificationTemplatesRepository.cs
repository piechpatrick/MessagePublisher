using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MessagePublisher.Common.Repositories;
using MessagePublisher.Models;

namespace MessagePublisher.Gateway.API.Repositories
{
    public class NotificationTemplatesRepository : INotificationTemplatesRepository
    {

        public ObservableCollection<NotificationTemplate> Tempalates { get;  set; }

        public NotificationTemplatesRepository()
        {
            this.Tempalates = new ObservableCollection<NotificationTemplate>();
            this.Seed(this.Tempalates);
        }
        public NotificationTemplate Get(NotificationTemplate item)
        {
            return this.Tempalates.Where(t => t == item)
                .FirstOrDefault();
        }

        public IEnumerable<NotificationTemplate> GetAll(Func<NotificationTemplate, bool> predicate)
        {
            return this.Tempalates
                .Where(predicate);
        }

        public IEnumerable<NotificationTemplate> GetAll()
        {
            return this.Tempalates;
        }

        public void TryAdd(NotificationTemplate item)
        {
            this.Tempalates.Add(item);
        }

        public void TryAdd(IEnumerable<NotificationTemplate> items)
        {
            foreach (var item in items)
            {
                this.Tempalates.Add(item);
            }
            
        }

        public void TryRemove(NotificationTemplate item)
        {
            var toRemove = this.Tempalates.Where(t => t.Guid == item.Guid).FirstOrDefault();
            if (toRemove != null)
                this.Tempalates.Remove(toRemove);
        }

        public void TryRemove(IEnumerable<NotificationTemplate> items)
        {
            foreach (var item in items)          
                this.TryRemove(item);           
        }

        public void TrySet(IEnumerable<NotificationTemplate> items)
        {
            foreach (var item in items)           
                this.TryAdd(item);          
        }
        public void TrySet(NotificationTemplate item)
        {
            var template = this.Tempalates.Where(t => t.Guid == item.Guid)
                .FirstOrDefault();
            if(template != null)
            {
                template.Message = item.Message;
                template.Name = item.Name;
                template.IsFavorite = item.IsFavorite;
                template.CloseAfter = item.CloseAfter;
                template.HasToConfirm = item.HasToConfirm;
                template.ImageIndex = item.ImageIndex;
            }
            
        }

        private void Seed(ObservableCollection<NotificationTemplate> notificationTemplates)
        {
            for (int i = 0; i < 10; i++)
            {
                notificationTemplates.Add(new NotificationTemplate() {   Name = $"Auto generated notificaiton {i}" });
            }
        }
    }
}
