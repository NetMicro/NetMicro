using NFlags.Commands;

namespace NetMicro.Queues.Kafka.NFlags
{
    public class ProducerConfig : IProducerConfig
    {
        private readonly CommandArgs _commandArgs;

        public ProducerConfig(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string BootstrapServers => _commandArgs.GetOption<string>(KafkaOptions.BootstrapServers);
    }
}