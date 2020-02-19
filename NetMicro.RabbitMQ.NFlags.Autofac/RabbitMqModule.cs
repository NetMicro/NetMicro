using Autofac;
using RabbitMQ.Client;

namespace NetMicro.RabbitMQ.NFlags.Autofac
{
    public class RabbitMqModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RabbitMqConfig>()
                .As<IRabbitMqConfig>()
                .SingleInstance();

            builder.RegisterType<global::RabbitMQ.Client.ConnectionFactory>().SingleInstance();
            builder.Register(context => context.Resolve<global::RabbitMQ.Client.ConnectionFactory>().CreateConnection())
                .As<IConnection>()
                .SingleInstance();

            builder.Register(context => context.Resolve<IConnection>().CreateModel())
                .As<IModel>()
                .InstancePerDependency();
        }
    }
}