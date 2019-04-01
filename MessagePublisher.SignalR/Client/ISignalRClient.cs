using MessagePublisher.SignalR.Client.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.SignalR.Client
{
    public interface ISignalRClient
    {
        ObservableCollection<IHubModule> ActiveModules { get; set; }
        Task Start();
    }
}
