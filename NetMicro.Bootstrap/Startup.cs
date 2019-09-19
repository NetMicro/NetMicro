using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NetMicro.Bootstrap.Config;
using NetMicro.Routing.Autofac;
using NetMicro.Routing.Owin;
using Configuration = NetMicro.Routing.Configuration;

namespace NetMicro.Bootstrap
{
    public abstract class Startup<TConfiguration> where TConfiguration : class
    {
        protected abstract void ConfigureContainer(ContainerBuilder builder);

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime lifetime,
            TConfiguration configuration)
        {
            loggerFactory.AddConsole();
            var container = BuildContainer(configuration, app, env, loggerFactory, lifetime);

            UseNetMicro(container, app, lifetime, loggerFactory);
        }

        private static void UseNetMicro(IContainer container, IApplicationBuilder app, IApplicationLifetime lifetime,
            ILoggerFactory loggerFactory)
        {
            var extensions = container.Resolve<IEnumerable<IExtension>>().ToArray();
            foreach (var extension in extensions)
                extension.Extend();

            app.UseNetMicro(new Configuration
            {
                Bootstrapper = new AutofacBootstrapper(container)
            });
        }

        private IContainer BuildContainer(
            TConfiguration configuration,
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime lifetime
        )
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(configuration);
            builder.RegisterInstance(env);
            builder.RegisterInstance(app);
            builder.RegisterInstance(lifetime);
            builder.RegisterInstance(loggerFactory);

            builder.RegisterType<NFlagsDevelopmentConfiguration>().As<IDevelopmentConfiguration>().SingleInstance();
            builder.RegisterModule<Modules.ErrorHandlingModule>();

            ConfigureContainer(builder);

            return builder.Build();
        }
    }
}