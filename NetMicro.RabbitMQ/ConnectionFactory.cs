using RabbitMQ.Client;
using RabbitMqClientConnectionFactory = RabbitMQ.Client.ConnectionFactory;

namespace NetMicro.RabbitMQ
{
    public class ConnectionFactory
    {
        private readonly IRabbitMqConfig _config;

        public ConnectionFactory(IRabbitMqConfig config)
        {
            _config = config;
        }

        public IConnection CreateConnection()
        {
            return new RabbitMqClientConnectionFactory
            {
                HostName = _config.HostName,
                Port = _config.Port,
                UserName = _config.UserName,
                Password = _config.Password,
                VirtualHost = _config.VirtualHost
            }.CreateConnection();
        }
    }
}