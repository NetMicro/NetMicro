using Autofac;
using MongoDB.Driver;
using NetMicro.MongoDB;
using NetMicro.MongoDB.NFlags;

namespace NetMicro.Bootstrap.Modules
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