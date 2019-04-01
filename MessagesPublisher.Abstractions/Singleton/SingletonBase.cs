using MessagesPublisher.Abstractions.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesPublisher.Abstractions.Singleton
{
    /// <summary>
    /// SingetonBase
    /// </summary>
    /// <typeparam name="TInstance"></typeparam>
    /// <typeparam name="TFactory"></typeparam>
    public abstract class SingletonBase<TInstance, TFactory>
        where TInstance : SingletonBase<TInstance, TFactory>
        where TFactory : IInstanceFactory<TInstance>, new()
    {
        private static volatile TInstance s_instance;

        /// <summary>
        /// syncRoot
        /// </summary>
        protected static readonly object s_syncRoot = new object();

        /// <summary>
        /// Default ctr
        /// </summary>
        protected SingletonBase()
        {
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static TInstance Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (s_syncRoot)
                    {
                        if (s_instance == null)
                        {
                            IInstanceFactory<TInstance> factory = new TFactory();
                            TInstance instance = factory.CreateInstance(s_syncRoot, false);

                            if (instance == null)
                            {
                                instance = factory.CreateInstance(s_syncRoot, true);
                                instance.OnInstanceCreated(true);
                            }
                            else
                                instance.OnInstanceCreated(false);

                            s_instance = instance;
                        }
                    }
                }

                return s_instance;
            }
        }

        /// <summary>
        /// OnInstanceCreated abstract method
        /// </summary>
        /// <param name="isDefault"></param>
        protected abstract void OnInstanceCreated(bool isDefault);
    }
}
