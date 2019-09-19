using Autofac;

namespace NetMicro.Queues.Kafka.NFlags.Autofac
{
    public class KafkaQueuesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsumerConfig>()
                .As<IConsumerConfig>()
                .SingleInstance();

            builder.RegisterType<ConsumerConfigFactory>()
                .SingleInstance();

            builder.Register(c => c.Resolve<ConsumerConfigFactory>().Create())
                .SingleInstance();

            builder.RegisterType<ProducerConfig>()
                .As<IProducerConfig>()
                .SingleInstance();

            builder.RegisterType<ProducerConfigFactory>()
                .SingleInstance();

            builder.Register(c => c.Resolve<ProducerConfigFactory>().Create())
                .SingleInstance();

            builder.RegisterGeneric(typeof(Consumer<>)).As(typeof(IConsumer<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Producer<>)).As(typeof(IProducer<>)).InstancePerDependency();
        }
    }
}