using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetMicro.ServiceBootstrap.Logging;
using NFlags;
using NFlags.Commands;

namespace NetMicro.ServiceBootstrap
{
    public static class CommandConfiguratorExtensions
    {
        private const string DevelopmentGroup = "Development";

        public static CommandConfigurator RegisterDevelopment(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterFlag(b => b
                    .Name(DevelopmentFlags.DisableSecurity)
                    .Description("Disables security")
                    .ConfigPath("Development:DisableSecurity")
                    .EnvironmentVariable("DEVELOPMENT_DISABLE_SECURITY")
                    .Group(DevelopmentGroup)
                );
        }

        public static CommandConfigurator RegisterServiceCommand<TStartup>(
            this CommandConfigurator configurator,
            string commandName,
            string commandDescription,
            IGenericConfig configuration,
            Action<CommandConfigurator, IGenericConfig> additionalConfiguration = null) where TStartup : class
        {
            return configurator.RegisterCommand(
                commandName,
                commandDescription,
                c => c.ConfigureService<TStartup>(configuration, additionalConfiguration)
            );
        }

        public static CommandConfigurator RegisterDefaultServiceCommand<TStartup>(
            this CommandConfigurator configurator,
            string commandName,
            string commandDescription,
            IGenericConfig configuration,
            Action<CommandConfigurator, IGenericConfig> additionalConfiguration = null) where TStartup : class
        {
            return configurator.RegisterDefaultCommand(
                commandName,
                commandDescription,
                c => c.ConfigureService<TStartup>(configuration, additionalConfiguration)
            );
        }

        private static CommandConfigurator ConfigureService<TStartup>(
            this CommandConfigurator configurator,
            IGenericConfig configuration,
            Action<CommandConfigurator, IGenericConfig> additionalConfiguration = null) where TStartup : class
        {
            configurator.RegisterOption<int>(b => b
                    .Name(ServiceOptions.Port)
                    .Abr("p")
                    .Description("Listening port")
                    .EnvironmentVariable("PORT")
                    .DefaultValue(5000)
                )
                .RegisterDevelopment()
                .SetExecute((commandArgs, output) =>
                {
                    RunKestrelHost<TStartup>(commandArgs, configuration, output);
                });

            additionalConfiguration?.Invoke(configurator, configuration);

            return configurator;
        }

        private static void RunKestrelHost<TStartup>(CommandArgs commandArgs, IGenericConfig config, IOutput output)
            where TStartup : class
        {
            var host = new WebHostBuilder()
                .UseContentRoot(GetContentRoot())
                .ConfigureServices(collection => collection
                    .AddSingleton(commandArgs)
                    .AddSingleton(config)
                )
                .ConfigureKestrel(options => options
                    .ListenAnyIP(commandArgs.GetOption<int>(ServiceOptions.Port))
                )
                .UseKestrel()
                .UseStartup<TStartup>()
                .ConfigureLogging(
                    builder => builder.AddNFlagsOutput(c =>
                    {
                        c.Output = output;
                        c.LogLevel = LogLevel.Information;
                    })
                )
                .Build();

            host.Run();
        }

        private static string GetContentRoot()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}