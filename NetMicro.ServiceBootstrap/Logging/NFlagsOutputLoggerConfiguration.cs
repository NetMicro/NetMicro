using Microsoft.Extensions.Logging;
using NFlags;

namespace NetMicro.ServiceBootstrap.Logging
{
    public class NFlagsOutputLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;

        public IOutput Output { get; set; }
    }

}