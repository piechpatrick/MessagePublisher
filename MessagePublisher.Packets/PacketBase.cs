using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Packets
{
    public abstract class PacketBase
    {
        public PacketBase()
        {
            this.Created = DateTime.Now;
        }

        public DateTime Created { get; set; }
    }
}
