namespace NetMicro.Queues.Kafka
{
    public interface IConsumerConfig
    {
        string GroupId { get; }
        string BootstrapServers { get; }
    }
}