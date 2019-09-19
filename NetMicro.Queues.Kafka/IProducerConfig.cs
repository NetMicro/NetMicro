namespace NetMicro.Queues.Kafka
{
    public interface IProducerConfig
    {
        string BootstrapServers { get; }
    }
}