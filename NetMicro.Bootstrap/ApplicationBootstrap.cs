using System;
using System.IO;
using NetMicro.Bootstrap.Config;
using NFlags;
using NFlags.Commands;
using Environment = NFlags.Environment;

namespace NetMicro.Bootstrap
{
    public static class ApplicationBootstrap
    {
        public static NFlags.Bootstrap Init(AppConfig appConfig,
            Action<CommandConfigurator> additionalConfiguration = null)
        {
            var configuration = new Configuration(GetContentRoot());
            return Cli.Configure(c => c
                    .SetName(appConfig.Name)
                    .SetDescription(appConfig.Description)
                    .SetDialect(Dialect.Gnu)
                    .SetEnvironment(Environment.Prefixed(appConfig.EnvPrefix))
                    .SetConfiguration(configuration)
                    .RegisterConverter(new StringToStringArrayConverter())
                )
                .Root(c =>
                {
                    c.PrintHelpOnExecute();

                    additionalConfiguration?.Invoke(c);
                });
        }

        private static string GetContentRoot()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}