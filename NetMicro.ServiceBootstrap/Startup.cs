using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetMicro.ErrorHandling;
using NetMicro.ErrorHandling.Autofac;
using NetMicro.ErrorHandling.NFlags;
using NetMicro.Routing.Autofac;
using NetMicro.Routing.Owin;
using NetMicro.ServiceBootstrap.Logging;
using Configuration = NetMicro.Routing.Configuration;

namespace NetMicro.ServiceBootstrap
{
    public abstract class Startup<TConfiguration> where TConfiguration : class
    {
        protected abstract void ConfigureContainer(ContainerBuilder builder);

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IHostApplicationLifetime lifetime,
            TConfiguration configuration)
        {
            var container = BuildContainer(configuration, app, env, loggerFactory, lifetime);

            UseNetMicro(container, app);
        }

        private static void UseNetMicro(IContainer container, IApplicationBuilder app)
        {
            var extensions = container.Resolve<IEnumerable<IExtension>>().ToArray();
            foreach (var extension in extensions)
                extension.Extend();

            var startupActions = container.Resolve<IEnumerable<IStartupAction>>().ToArray();
            foreach (var startupAction in startupActions)
                startupAction.Execute();

            app.UseNetMicro(new Configuration
            {
                Bootstrapper = new AutofacBootstrapper(container)
            });
        }

        private IContainer BuildContainer(
            TConfiguration configuration,
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IHostApplicationLifetime lifetime
        )
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(configuration);
            builder.RegisterInstance(env);
            builder.RegisterInstance(app);
            builder.RegisterInstance(lifetime);
            builder.RegisterInstance(loggerFactory);

            builder.RegisterCallback(rb => rb.AddRegistrationSource(new LoggerRegistrationSource()));

            builder.UseErrorHandling();
            builder.RegisterType<ErrorHandlingConfiguration>().As<IErrorHandlingConfiguration>().SingleInstance();

            ConfigureContainer(builder);

            return builder.Build();
        }
    }
}