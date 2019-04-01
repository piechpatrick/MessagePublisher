using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MessagesPublisher.Abstractions.Repositories
{
    /// <summary>
    /// Read-only repository
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public interface IReadOnlyRepository<TItem>
        where TItem : class
    {
        /// <summary>
        /// Get specific entity
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        TItem Get(TItem id);
        /// <summary>
        /// Get many
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<TItem> GetAll(Func<TItem, bool> predicate);
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<TItem> GetAll();
    }
}
