using Consul;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetMicro.Consul
{
    public static class Consul
    {
        public static void RegisterWithConsul(this IHostApplicationLifetime lifetime,
            IConsulConfiguration consulConfiguration, ILoggerFactory loggerFactory)
        {
            if (!consulConfiguration.Enabled)
                return;

            var consulClient = new ConsulClient(config => { config.Address = consulConfiguration.ConsulAddress; });

            var logger = loggerFactory.CreateLogger<IHostApplicationLifetime>();

            var address = consulConfiguration.ServiceUri;

            var registration = new AgentServiceRegistration
            {
                ID = $"{consulConfiguration.ServiceId}-{address.Port}",
                Name = consulConfiguration.ServiceName,
                Address = $"{address.Scheme}://{address.Host}",
                Port = address.Port,
                Tags = consulConfiguration.Tags
            };

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });
        }
    }
}