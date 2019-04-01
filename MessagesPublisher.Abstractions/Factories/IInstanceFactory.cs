using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesPublisher.Abstractions.Factories
{
    public interface IInstanceFactory<T>
    {
        T CreateInstance(object syncRoot, bool forceDefault);
    }
}
