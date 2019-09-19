using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using NetMicro.Http;

namespace NetMicro.Routing.Binding
{
    public class ContentParserResolver
    {
        private readonly Context _context;
        private readonly IEnumerable<IContentParserFactory> _factories;

        public ContentParserResolver(
            Context context,
            IEnumerable<IContentParserFactory> factories)
        {
            _context = context;
            _factories = factories;
        }

        public IContentParser Create()
        {
            if (!_context.Request.Headers.ContainsKey("Content-Type"))
                return null;

            return _context.Request.GetMimeTypes()
                .Select(GetParser)
                .FirstOrDefault(contentParser => contentParser != null);
        }

        private IContentParser GetParser(string mimeType)
        {
            var factory = _factories.FirstOrDefault(f => f.ContentType == mimeType) ?? _factories.First();
            return factory?.GetParser();
        }
    }
}