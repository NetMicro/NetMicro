using Confluent.Kafka;

namespace NetMicro.Queues.Kafka
{
    public class ConsumerConfigFactory
    {
        private readonly IConsumerConfig _consumerConfig;

        public ConsumerConfigFactory(IConsumerConfig consumerConfig)
        {
            _consumerConfig = consumerConfig;
        }

        public ConsumerConfig Create()
        {
            return new ConsumerConfig
            {
                GroupId = _consumerConfig.GroupId,
                BootstrapServers = _consumerConfig.BootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }
    }
}