using System;

namespace NetMicro.Http
{
    public class Url
    {
        public Url(string method, string url)
        {
            var uri = new Uri(url);
            Method = method;
            Scheme = uri.Scheme;
            HostName = uri.Host;
            Port = uri.Port;
            Path = uri.LocalPath;
            Query = uri.Query;
        }

        public Url(string method, string scheme, string hostName, int? port, string path, string query)
        {
            Method = method;
            Scheme = scheme;
            HostName = hostName;
            Port = port;
            Path = path;
            Query = query;
        }

        public string Method { get; }
        public string Scheme { get; }
        public string HostName { get; }
        public int? Port { get; }
        public string Path { get; }
        public string Query { get; }
    }
}