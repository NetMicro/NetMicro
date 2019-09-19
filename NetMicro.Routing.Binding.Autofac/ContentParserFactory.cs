using System;

namespace NetMicro.Routing.Binding.Autofac
{
    public class ContentParserFactory<TContentParser> : IContentParserFactory where TContentParser : IContentParser
    {
        private readonly Lazy<TContentParser> _parser;

        public ContentParserFactory(string contentType, Lazy<TContentParser> parser)
        {
            ContentType = contentType;
            _parser = parser;
        }

        public string ContentType { get; }
        public IContentParser GetParser() => _parser.Value;
    }
}