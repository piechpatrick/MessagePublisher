using MessagePublisher.Client.Modules;
using MessagePublisher.Client.Repositories;
using MessagePublisher.Client.Services;
using MessagePublisher.Common.Repositories;
using MessagePublisher.Packets;
using MessagePublisher.SignalR.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagePublisher.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new SignalRClientBuilder();
            var client = builder
                .AddHubModule<NotificationHubModule>()
                .Build();
            IServiceCollection services = builder.GetServiceCollection();
            services.AddSingleton<Form1>();
            services.AddSingleton<INotificationTemplatesRepository, NotificationTemplatesRepository>();
            services.AddSingleton<INotificationTemplatesService, NotificationTemplatesService>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<IIconsService, IconsService>();

            var root = builder.GetServiceProvider().GetService<Form1>();
            Visualization.Instance.AddService(root as IPopupService);
            Visualization.Instance.AddService(root as IUpdatable<UpdateNotificationTemplatesPacket>);
            Application.Run(root);
            Application.ThreadException += Application_ThreadException;
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            
        }
    }
}
