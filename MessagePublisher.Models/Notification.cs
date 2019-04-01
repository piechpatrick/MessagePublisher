using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.Models
{
    public class Notification : EntityBase
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
