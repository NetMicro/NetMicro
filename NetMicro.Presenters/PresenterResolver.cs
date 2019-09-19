using System;
using System.Collections.Generic;
using System.Linq;
using NetMicro.Http;
using NetMicro.Routing;

namespace NetMicro.Presenters
{
    public class PresenterResolver
    {
        private readonly Context _context;
        private readonly IEnumerable<IPresenterFactory> _factories;

        public PresenterResolver(
            Context context,
            IEnumerable<IPresenterFactory> factories)
        {
            _context = context;
            _factories = factories;
        }

        public IHttpPresenter Create()
        {
            var mimeTypes = _context.Request.GetResponseMimeTypesPriority();
            if (!mimeTypes.Any())
                return null;

            return mimeTypes
                .Select(GetPresenter)
                .FirstOrDefault(contentParser => contentParser != null);
        }

        private IHttpPresenter GetPresenter(string mimeType)
        {
            if (!_factories.Any())
                throw new Exception("No presenters registered!");

            var factory = _factories.FirstOrDefault(f => f.ContentType == mimeType) ?? _factories.First();
            return factory.GetPresenter();
        }
    }
}