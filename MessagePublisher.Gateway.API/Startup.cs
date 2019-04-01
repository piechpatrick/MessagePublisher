using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagePublisher.Common.Repositories;
using MessagePublisher.Gateway.API.Hubs;
using MessagePublisher.Gateway.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MessagePublisher.Gateway.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSignalR();
            services.AddSingleton<INotificationTemplatesRepository, NotificationTemplatesRepository>();
            services.AddSingleton<NotificationsHub>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationsHub>("/notificationsHub");
            });

            app.UseMvc();
        }
    }
}
