using Autofac;
using NetMicro.Bootstrap.Modules;

namespace NetMicro.Bootstrap
{
    public static class ContainerBuilderExtensions
    {
        public static void UseMongoDb(this ContainerBuilder builder)
        {
            builder.RegisterModule<MongoDbExtensionModule>();
        }

        public static void UseConsul(this ContainerBuilder builder)
        {
            builder.RegisterModule<ConsulExtensionModule>();
        }

        public static void UsePrometheus(this ContainerBuilder builder)
        {
            builder.RegisterModule<PrometheusExtensionModule>();
        }
    }
}