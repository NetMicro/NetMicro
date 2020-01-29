using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetMicro.Consul;

namespace NetMicro.ServiceBootstrap.Extensions
{
    public class ConsulExtension : IExtension
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IConsulConfiguration _consulConfiguration;
        private readonly ILoggerFactory _loggerFactory;

        public ConsulExtension(
            IHostApplicationLifetime applicationLifetime,
            IConsulConfiguration consulConfiguration,
            ILoggerFactory loggerFactory)
        {
            _consulConfiguration = consulConfiguration;
            _loggerFactory = loggerFactory;
            _applicationLifetime = applicationLifetime;
        }

        public void Extend()
        {
            _applicationLifetime.RegisterWithConsul(_consulConfiguration, _loggerFactory);
        }
    }
}