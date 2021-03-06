using System;
using Microsoft.Extensions.Logging;

namespace NetMicro.ServiceBootstrap.Logging
{
    public class NFlagsOutputLogger : ILogger
    {
        private readonly string _name;
        private readonly NFlagsOutputLoggerConfiguration _config;

        public NFlagsOutputLogger(string name, NFlagsOutputLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                _config.Output.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}");
            }
        }
    }
}