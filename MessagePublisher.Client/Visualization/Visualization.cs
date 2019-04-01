using MessagePublisher.Packets;
using MessagesPublisher.Abstractions.Factories;
using MessagesPublisher.Abstractions.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client
{
    public class Visualization : SingletonBase<Visualization, VisualizationFactory>
    {
        public IPopupService PopupService { get; private set; }
        public IUpdatable<UpdateNotificationTemplatesPacket> NotificationTemplatesUpdater { get; private set; }
        public Visualization()
        {

        }

        public void AddService(IPopupService popupService)
        {
            this.PopupService = popupService;
        }

        public void AddService(IUpdatable<UpdateNotificationTemplatesPacket> updatable)
        {
            this.NotificationTemplatesUpdater = updatable;
        }


        protected override void OnInstanceCreated(bool isDefault)
        {
            
        }
    }

    public class VisualizationFactory : IInstanceFactory<Visualization>
    {
        public Visualization CreateInstance(object syncRoot, bool forceDefault)
        {
            return new Visualization();
        }
    }
}
