using NFlags.Commands;

namespace NetMicro.Queues.Kafka.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string KafkaGroup = "Kafka";

        public static CommandConfigurator RegisterKafka(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(KafkaOptions.GroupId)
                    .Description("Protocol string to use when connecting to MongoDb")
                    .ConfigPath("Kafka:GroupId")
                    .EnvironmentVariable("KAFKA_GROUP_ID")
                    .Group(KafkaGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(KafkaOptions.BootstrapServers)
                    .Description("Kafka bootstrap servers")
                    .ConfigPath("Kafka:BootstrapServers")
                    .EnvironmentVariable("KAFKA_BOOTSTRAP_SERVERS")
                    .Group(KafkaGroup)
                );
        }
    }
}