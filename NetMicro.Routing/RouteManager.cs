using System.Collections.Generic;
using System.Linq;
using NetMicro.Http;

namespace NetMicro.Routing
{
    internal class RouteManager
    {
        private readonly IList<IRoute> _routes = new List<IRoute>();

        public void Add(IRoute route)
        {
            _routes.Add(route);
        }

        public IRequestHandler FindRoute(Request request, IResponse response)
        {
            return _routes
                .Select(route => route.GetRequestHandler(request, response))
                .FirstOrDefault(handler => handler != null);
        }
    }
}