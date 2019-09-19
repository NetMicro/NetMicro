namespace NetMicro.RabbitMQ
{
    public interface IRabbitMqConfig
    {
        string HostName { get; }
        int Port { get; }
        string UserName { get; }
        string Password { get; }
        string VirtualHost { get; }
    }
}