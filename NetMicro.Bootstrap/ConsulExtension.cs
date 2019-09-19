using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NetMicro.Consul;

namespace NetMicro.Bootstrap
{
    public class ConsulExtension : IExtension
    {
        private readonly IApplicationLifetime _applicationLifetime;
        private readonly IConsulConfiguration _consulConfiguration;
        private readonly ILoggerFactory _loggerFactory;

        public ConsulExtension(
            IApplicationLifetime applicationLifetime,
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