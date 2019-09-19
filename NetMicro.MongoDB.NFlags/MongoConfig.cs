using System.Collections.Generic;
using System.Linq;
using NFlags.Commands;

namespace NetMicro.MongoDB.NFlags
{
    public class MongoConfig : IMongoConfig
    {
        private readonly CommandArgs _commandArgs;

        public MongoConfig(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string Protocol => _commandArgs.GetOption<string>(MongoDbOptions.Protocol);
        public IEnumerable<string> Hosts => _commandArgs.GetOption<string[]>(MongoDbOptions.Hosts);

        public IDictionary<string, string> Options => _commandArgs
            .GetOption<string>(MongoDbOptions.Options)
            ?.Split(",")
            ?.ToDictionary(s => s.Split("=")[0], s => s.Split("=")[1]) ?? new Dictionary<string, string>();

        public string Username => _commandArgs.GetOption<string>(MongoDbOptions.Username);
        public string Password => _commandArgs.GetOption<string>(MongoDbOptions.Password);
    }
}