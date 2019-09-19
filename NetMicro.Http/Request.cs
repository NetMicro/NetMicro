using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetMicro.Http
{
    public class Request
    {
        public Request(
            Url url,
            IDictionary<string, IEnumerable<string>> headers,
            Stream body
        )
        {
            Url = url;
            Headers = headers;
            Body = body;
        }

        public string Method => Url.Method;

        public Url Url { get; }

        public string Path => Url.Path;

        public string Query => Url.Query;

        public string Scheme => Url.Scheme;

        public Stream Body { get; }
        public IDictionary<string, IEnumerable<string>> Headers { get; }
    }
}