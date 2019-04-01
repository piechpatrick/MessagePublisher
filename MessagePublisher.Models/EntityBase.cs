using MessagesPublisher.Abstractions.Bindable;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Models
{
    public class EntityBase : BindableBase
    {
        public EntityBase()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; set; }
    }
}
