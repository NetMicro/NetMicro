using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace NetMicro.ServiceBootstrap.Logging
{
    public class NFlagsOutputLoggerProvider : ILoggerProvider
    {
        private readonly NFlagsOutputLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, NFlagsOutputLogger> _loggers = new ConcurrentDictionary<string, NFlagsOutputLogger>();

        public NFlagsOutputLoggerProvider(NFlagsOutputLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new NFlagsOutputLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}