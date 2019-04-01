﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesPublisher.Abstractions.Builders
{
    /// <summary>
    /// BuilderBase, TODO: Imporve with DI
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TBuilderOptions"></typeparam>
    public abstract class BuilderBase<TBuilder, TResult, TBuilderOptions> : IBuilder<TBuilder, TResult>
        where TBuilder : class, IBuilder<TBuilder, TResult>
        where TBuilderOptions : class, IBuilderOptions
    {
        //Service Collection
        protected IServiceCollection serviceCollection;
        protected Func<IServiceProvider> serviceProviderFactory;

        //Builder Options
        protected TBuilderOptions options;

        protected Action<ILoggingBuilder> loggingBuilder;

        protected IServiceProvider serviceProvider;

        /// <summary>
        /// BuilderBase
        /// </summary>
        public BuilderBase()
        {
            this.options = Activator.CreateInstance<TBuilderOptions>();
            serviceCollection = this.GetServiceCollection();
            serviceCollection.AddSingleton<TBuilderOptions>(this.options);
        }

        public IServiceCollection GetServiceCollection()
        {
            if (this.serviceCollection == null)
                this.serviceCollection = new ServiceCollection();
            return this.serviceCollection;
        }

        public TBuilder SetServiceCollection(IServiceCollection serviceCollectionn, Func<IServiceProvider> serviceProviderFactory = null)
        {
            serviceCollection = serviceCollectionn;
            this.serviceProviderFactory = serviceProviderFactory;
            return this as TBuilder;
        }

        public TBuilder SetOptions(TBuilderOptions builderOptions)
        {
            this.options = builderOptions;
            return this as TBuilder;
        }

        public TBuilder ConfigureLogging(Action<ILoggingBuilder> loggingBuilder)
        {
            this.loggingBuilder = loggingBuilder;
            return this as TBuilder;
        }

        public abstract IServiceProvider GetServiceProvider(IServiceProvider serviceProvider);


        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        public abstract TResult Build();
    }
}
