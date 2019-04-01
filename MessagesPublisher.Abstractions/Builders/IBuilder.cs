using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesPublisher.Abstractions.Builders
{
    /// <summary>
    /// Build
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IBuilder<TBuilder, TResult>
    {

        IServiceCollection GetServiceCollection();
        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        TResult Build();
    }
}
