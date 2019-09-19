using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using NFlags;

namespace NetMicro.Bootstrap.Config
{
    public class Configuration : IGenericConfig
    {
        private readonly IConfigurationRoot _configuration;

        public Configuration(string baseDirectory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(baseDirectory)
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public bool Has(string path)
        {
            return _configuration.GetSection(path).Exists();
        }

        public T Get<T>(string path)
        {
            return _configuration.GetSection(path).Get<T>();
        }
    }
}