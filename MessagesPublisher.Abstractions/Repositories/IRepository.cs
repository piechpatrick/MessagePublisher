using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesPublisher.Abstractions.Repositories
{
    public interface IRepository<TItem> : IReadOnlyRepository<TItem>
        where TItem : class
    {
        /// <summary>
        /// TryAdd
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void TryAdd(TItem item);
        /// <summary>
        /// TryAdd
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        void TryAdd(IEnumerable<TItem> items);
        /// <summary>
        /// TryRemove
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void TryRemove(TItem item);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        void TryRemove(IEnumerable<TItem> items);
        /// <summary>
        /// TrySet
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        void TrySet(IEnumerable<TItem> items);
    }
}
