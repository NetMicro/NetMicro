using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NetMicro.Bootstrap.Config;
using NetMicro.Consul.NFlags;
using NetMicro.Monitoring.Prometheus.NFlags;
using NFlags;
using NFlags.Commands;
using NFlags.TypeConverters;
using Environment = NFlags.Environment;

namespace NetMicro.Bootstrap
{
    public static class ServiceBootstrap
    {
        private const string ServiceGroup = "Service";

        public static NFlags.Bootstrap Init<TStartup>(ServiceConfig serviceConfig,
            Action<CommandConfigurator> additionalConfiguration = null) where TStartup : class
        {
            var configuration = new Configuration(GetContentRoot());
            return Cli.Configure(c => c
                    .SetName(serviceConfig.Name)
                    .SetDescription(serviceConfig.Description)
                    .SetDialect(Dialect.Gnu)
                    .SetEnvironment(Environment.Prefixed(serviceConfig.EnvPrefix))
                    .SetConfiguration(configuration)
                    .RegisterConverter(new StringToStringArrayConverter())
                )
                .Root(c =>
                {
                    c.RegisterOption<int>(b => b
                            .Name(ServiceOptions.Port)
                            .Abr("p")
                            .Description("Listening port")
                            .EnvironmentVariable("PORT")
                            .DefaultValue(5000)
                            .Group(ServiceGroup)
                        )
                        .RegisterDevelopment()
                        .RegisterConsulServiceDiscovery()
                        .RegisterPrometheusMetrics()
                        .SetExecute((commandArgs, output) =>
                        {
                            RunKestrelHost<TStartup>(commandArgs, configuration, output);
                        });

                    additionalConfiguration?.Invoke(c);
                });
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
                .Build();

            host.Run();
        }

        private static string GetContentRoot()
        {
            return Directory.GetCurrentDirectory();
        }
    }

    public class StringToStringArrayConverter : IArgumentConverter
    {
        public bool CanConvert(Type type)
        {
            return type == typeof(string);
        }

        public object Convert(Type type, string value)
        {
            return value.Split(";", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}