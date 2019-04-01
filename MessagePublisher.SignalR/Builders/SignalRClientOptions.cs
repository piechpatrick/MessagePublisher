using MessagesPublisher.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.SignalR.Builders
{
    public class SignalRClientOptions : IBuilderOptions
    {
        public bool Active { get; set; }
    }
}
