using MessagePublisher.SignalR.Client.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.SignalR.Client.Controllers
{
    public class HubModulesController : IHubModulesController
    {

        private IList<IHubModule> hubModules;

        public HubModulesController()
        {
            this.hubModules = new List<IHubModule>();
        }

        public void AddModule(IHubModule hubModule)
        {
            this.hubModules.Add(hubModule);
        }

        public IEnumerable<IHubModule> GetModules()
        {
            return this.hubModules;
        }
    }
}
