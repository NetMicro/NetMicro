using System;
using System.IO;
using NetMicro.Bootstrap.Config;
using NFlags;
using NFlags.Commands;
using NFlags.TypeConverters;
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