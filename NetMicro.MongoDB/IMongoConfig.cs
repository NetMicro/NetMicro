using System.Collections.Generic;

namespace NetMicro.MongoDB
{
    public interface IMongoConfig
    {
        string Protocol { get; }
        IEnumerable<string> Hosts { get; }
        IDictionary<string, string> Options { get; }

        string Username { get; }
        string Password { get; }
    }
}