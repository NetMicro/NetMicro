using MongoDB.Driver;

namespace NetMicro.MongoDB
{
    public static class MongoClientFactory
    {
        public static MongoClient Create(IMongoConfig config)
        {
            return new MongoClient(new MongoConnectionString(config));
        }
    }
}