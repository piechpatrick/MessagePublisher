using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagePublisher.Common.Repositories;
using MessagePublisher.Gateway.API.Hubs;
using MessagePublisher.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagePublisher.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTemlatesController : ControllerBase
    {
        private readonly INotificationTemplatesRepository notificationTemplatesRepository;
        private readonly NotificationsHub notificationsHub;
        public NotificationTemlatesController(INotificationTemplatesRepository notificationTemplatesRepository,
            NotificationsHub notificationsHub)
        {
            this.notificationTemplatesRepository = notificationTemplatesRepository;
            this.notificationsHub = notificationsHub;
        }
        // GET: api/NotificationTemlates
        [HttpGet]
        public IEnumerable<NotificationTemplate> Get()
        {
            return this.notificationTemplatesRepository.GetAll();
        }

        // GET: api/NotificationTemlates/5
        [HttpGet("{id}", Name = "Get")]
        public NotificationTemplate Get(NotificationTemplate item)
        {
            return this.notificationTemplatesRepository.Get(item);
        }

        // POST: api/NotificationTemlates
        [HttpPost]
        public async void Post([FromBody] NotificationTemplate item)
        {
            this.notificationTemplatesRepository.TryAdd(item);

            var added = new List<NotificationTemplate>();
            added.Add(item);
            await this.notificationsHub.Update(new Packets.UpdateNotificationTemplatesPacket() { Added = added });
        }
        [HttpPut]
        // PUT: api/NotificationTemlates/5
        public async void Put([FromBody] NotificationTemplate item)
        {
            this.notificationTemplatesRepository.TrySet(item);
            var updated = new List<NotificationTemplate>();
            updated.Add(item);
            await this.notificationsHub.Update(new Packets.UpdateNotificationTemplatesPacket() { Updated = updated });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async void Delete([FromBody]NotificationTemplate item)
        {
            this.notificationTemplatesRepository.TryRemove(item);
            var removed = new List<NotificationTemplate>();
            removed.Add(item);
            await this.notificationsHub.Update(new Packets.UpdateNotificationTemplatesPacket() { Removed = removed });
        }
    }
}
