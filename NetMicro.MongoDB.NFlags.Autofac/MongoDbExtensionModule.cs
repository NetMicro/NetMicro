using Autofac;
using MongoDB.Driver;

namespace NetMicro.MongoDB.NFlags.Autofac
{
    public class MongoDbExtensionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<MongoConfig>()
                .As<IMongoConfig>()
                .SingleInstance();

            builder
                .Register(c => MongoClientFactory.Create(c.Resolve<IMongoConfig>()))
                .As<MongoClient>()
                .SingleInstance();
        }
    }
}