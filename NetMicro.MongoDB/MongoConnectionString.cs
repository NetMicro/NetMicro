using System.Collections.Generic;
using System.Linq;

namespace NetMicro.MongoDB
{
    public class MongoConnectionString
    {
        private readonly IMongoConfig _config;

        public MongoConnectionString(IMongoConfig config)
        {
            _config = config;
        }

        public string Protocol => _config.Protocol;
        public IEnumerable<string> Hosts => _config.Hosts;
        public IDictionary<string, string> Options => _config.Options;
        public string Username => _config.Username;
        public string Password => _config.Password;

        public static implicit operator string(MongoConnectionString cs)
        {
            var csString = cs.Protocol + "://";
            if (!string.IsNullOrEmpty(cs.Username))
            {
                csString += cs.Username;
                if (!string.IsNullOrEmpty(cs.Password))
                    csString += ":" + cs.Password;
                csString += "@";
            }

            csString += string.Join(',', cs.Hosts);
            if (cs.Options.Any())
                csString += "?" + string.Join('&', cs.Options.Select(pair => pair.Key + "=" + pair.Value));

            return csString;
        }
    }
}