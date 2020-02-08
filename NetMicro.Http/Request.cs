using System;
using System.Collections.Generic;
using System.IO;

namespace NetMicro.Http
{
    public class Request
    {
        private Query _query;

        public Request(
            Url url,
            IDictionary<string, IEnumerable<string>> headers,
            Stream body
        )
        {
            Url = url;
            Headers = headers;
            Body = body;
            _query = QueryStringParser.Parse(Url.Query);
        }

        public string Method => Url.Method;

        public Url Url { get; }

        public string Path => Url.Path;

        public string QueryString => Url.Query;
        public Query Query => _query;

        public string Scheme => Url.Scheme;

        public Stream Body { get; }
        public IDictionary<string, IEnumerable<string>> Headers { get; }
    }

    public class InvalidQueryParam : Exception
    {
        public InvalidQueryParam(string query)
            : base($"'{query}' is not proper query parameter.")
        {
        }
    }
}