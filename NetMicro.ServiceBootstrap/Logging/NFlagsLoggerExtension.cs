using System;
using Microsoft.Extensions.Logging;

namespace NetMicro.ServiceBootstrap.Logging
{
    public static class NFlagsLoggerExtension
    {
        public static ILoggerFactory AddNFlagsOutput(this ILoggerFactory loggerFactory)
        {
            var config = new NFlagsOutputLoggerConfiguration();
            return loggerFactory.AddNFlagsOutput(config);
        }

        public static ILoggerFactory AddNFlagsOutput(this ILoggerFactory loggerFactory, NFlagsOutputLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new NFlagsOutputLoggerProvider(config));
            return loggerFactory;
        }

        public static ILoggerFactory AddNFlagsOutput(this ILoggerFactory loggerFactory, Action<NFlagsOutputLoggerConfiguration> configure)
        {
            var config = new NFlagsOutputLoggerConfiguration();
            configure(config);
            return loggerFactory.AddNFlagsOutput(config);
        }

        public static ILoggingBuilder AddNFlagsOutput(this ILoggingBuilder loggingBuilder)
        {
            var config = new NFlagsOutputLoggerConfiguration();
            return loggingBuilder.AddNFlagsOutput(config);
        }

        public static ILoggingBuilder AddNFlagsOutput(this ILoggingBuilder loggingBuilder, NFlagsOutputLoggerConfiguration config)
        {
            loggingBuilder.AddProvider(new NFlagsOutputLoggerProvider(config));
            return loggingBuilder;
        }

        public static ILoggingBuilder AddNFlagsOutput(this ILoggingBuilder loggingBuilder, Action<NFlagsOutputLoggerConfiguration> configure)
        {
            var config = new NFlagsOutputLoggerConfiguration();
            configure(config);
            return loggingBuilder.AddNFlagsOutput(config);
        }
    }
}