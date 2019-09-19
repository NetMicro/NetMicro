using NFlags.Commands;

namespace NetMicro.Queues.Kafka.NFlags
{
    public class ConsumerConfig : IConsumerConfig
    {
        private readonly CommandArgs _commandArgs;

        public ConsumerConfig(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string GroupId => _commandArgs.GetOption<string>(KafkaOptions.GroupId);
        public string BootstrapServers => _commandArgs.GetOption<string>(KafkaOptions.BootstrapServers);
    }
}