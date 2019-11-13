using Autofac;

namespace NetMicro.MongoDB.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseMongoDb(this ContainerBuilder builder)
        {
            builder.RegisterModule<MongoDbExtensionModule>();
        }
    }
}