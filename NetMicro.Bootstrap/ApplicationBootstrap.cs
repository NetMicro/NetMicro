using System;
using System.IO;
using NetMicro.Bootstrap.Config;
using NetMicro.Bootstrap.Converters;
using NFlags;
using NFlags.Commands;
using Environment = NFlags.Environment;

namespace NetMicro.Bootstrap
{
    public static class ApplicationBootstrap
    {
        public static NFlags.Bootstrap Init(ApplicationConfig applicationConfig,
            Action<CommandConfigurator, IGenericConfig> additionalConfiguration = null)
        {
            var configuration = new Configuration(GetContentRoot());
            return Cli.Configure(c => c
                    .SetName(applicationConfig.Name)
                    .SetDescription(applicationConfig.Description)
                    .SetDialect(Dialect.Gnu)
                    .SetEnvironment(Environment.Prefixed(applicationConfig.EnvPrefix))
                    .SetConfiguration(configuration)
                    .RegisterConverter(new StringToStringArrayConverter())
                )
                .Root(c =>
                {
                    c.PrintHelpOnExecute();

                    additionalConfiguration?.Invoke(c, configuration);
                });
        }

        private static string GetContentRoot()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}