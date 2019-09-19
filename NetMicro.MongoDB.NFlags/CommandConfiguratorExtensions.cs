using NFlags.Commands;

namespace NetMicro.MongoDB.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string MongoDbGroup = "MongoDB";

        public static CommandConfigurator RegisterMongoDb(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(MongoDbOptions.Protocol)
                    .Description("Protocol string to use when connecting to MongoDb")
                    .ConfigPath("MongoDB:Protocol")
                    .EnvironmentVariable("MONGODB_PROTOCOL")
                    .DefaultValue("mongodb")
                    .Group(MongoDbGroup)
                )
                .RegisterOption<string[]>(b => b
                    .Name(MongoDbOptions.Hosts)
                    .Description("MongoDb host. Can be set multiple times for multiple hosts. When using Environment Variable separate values with comma.")
                    .ConfigPath("MongoDB:Hosts")
                    .EnvironmentVariable("MONGODB_HOSTS")
                    .Group(MongoDbGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(MongoDbOptions.Username)
                    .Description("MongoDb username")
                    .ConfigPath("MongoDB:Username")
                    .EnvironmentVariable("MONGODB_USERNAME")
                    .Group(MongoDbGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(MongoDbOptions.Password)
                    .Description("MongoDb password")
                    .ConfigPath("MongoDB:Password")
                    .EnvironmentVariable("MONGODB_PASSWORD")
                    .Group(MongoDbGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(MongoDbOptions.Options)
                    .Description("MongoDb connection options in format 'option=value,option2=value'")
                    .ConfigPath("MongoDB:Options")
                    .EnvironmentVariable("MONGODB_OPTIONS")
                    .Group(MongoDbGroup)
                );
        }
    }
}