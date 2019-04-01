using MessagePublisher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Packets
{
    public class UpdateNotificationTemplatesPacket : PacketBase
    {
        public UpdateNotificationTemplatesPacket()
        {
            this.Added = new List<NotificationTemplate>();
            this.Removed = new List<NotificationTemplate>();
            this.Updated = new List<NotificationTemplate>();
        }
        public List<NotificationTemplate> Added { get; set; }

        public List<NotificationTemplate> Removed { get; set; }

        public List<NotificationTemplate> Updated { get; set; }
    }
}
