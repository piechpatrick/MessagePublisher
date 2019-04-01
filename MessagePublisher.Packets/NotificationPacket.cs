using MessagePublisher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Packets
{
    public class NotificationPacket : PacketBase
    {
        public NotificationTemplate Notification { get; set; }
    }
}
