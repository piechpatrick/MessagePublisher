using MessagePublisher.SignalR.Client.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.SignalR.Client.Controllers
{
    public interface IHubModulesController
    {
        void AddModule(IHubModule hubModule);
        IEnumerable<IHubModule> GetModules();

    }
}
