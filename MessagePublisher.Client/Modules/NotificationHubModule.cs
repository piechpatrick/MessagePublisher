using MessagePublisher.Client.Handlers;
using MessagePublisher.Packets;
using MessagePublisher.SignalR.Client.Modules;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Modules
{
    public class NotificationHubModule : HubModuleBase
    {
        public NotificationHubModule()
            :base()
        {
            this.AddPacketHandler<NotificationPacketHandler>();
            this.AddPacketHandler<UpdateNotificationTemplatesPacketHandler>();
        }

        public override string Url => "http://localhost:58995/notificationsHub";
    }
}
