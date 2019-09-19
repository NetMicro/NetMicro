using Confluent.Kafka;

namespace NetMicro.Queues.Kafka
{
    public class ProducerConfigFactory
    {
        private readonly IProducerConfig _consumerConfig;

        public ProducerConfigFactory(IProducerConfig consumerConfig)
        {
            _consumerConfig = consumerConfig;
        }

        public ProducerConfig Create()
        {
            return new ProducerConfig
            {
                BootstrapServers = _consumerConfig.BootstrapServers,
                Acks = Acks.None
            };
        }
    }
}