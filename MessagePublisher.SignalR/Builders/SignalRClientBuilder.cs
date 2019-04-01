using MessagePublisher.SignalR.Client;
using MessagePublisher.SignalR.Client.Controllers;
using MessagePublisher.SignalR.Client.Modules;
using MessagesPublisher.Abstractions.Builders;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePublisher.SignalR.Builders
{
    public class SignalRClientBuilder : BuilderBase<ISignalRClientBuilder, ISignalRClient, SignalRClientOptions>, ISignalRClientBuilder
    {
        protected List<IHubModule> hubModules;
        public SignalRClientBuilder()
            :base()
        {
            this.hubModules = new List<IHubModule>();
        }
        public ISignalRClientBuilder AddHubModule<T>()
            where T : IHubModule
        {
            this.hubModules.Add(Activator.CreateInstance<T>());
            return this;
        }

        public override ISignalRClient Build()
        {
            if (this.loggingBuilder == null)
            {
                this.loggingBuilder = (loggingBuilder) =>
                {

                };

            }
            serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddConsole());
            this.serviceCollection.AddSingleton<ISignalRClient, SignalRClient>();
            this.serviceCollection.AddSingleton<IHubModulesController, HubModulesController>();
            serviceProvider = this.GetServiceProvider();
            return serviceProvider.GetService<ISignalRClient>();
        }

        public override IServiceProvider GetServiceProvider(IServiceProvider serviceProvider = null)
        {
            if (serviceProvider == null)
                serviceProvider = this.serviceProviderFactory != null ? this.serviceProviderFactory.Invoke() : serviceCollection.BuildServiceProvider();

            var controller = serviceProvider.GetService<IHubModulesController>();
            foreach (var hubModule in this.hubModules)
            {
                controller.AddModule(hubModule);
            }
            return serviceProvider;
        }
    }
}
