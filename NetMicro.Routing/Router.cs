using System.Threading.Tasks;
using NetMicro.Http;
using NetMicro.Routing.SpecialRoutes;

namespace NetMicro.Routing
{
    public class Router : IRouter
    {
        private readonly IMiddlewareManager _middlewareManager = new MiddlewareManager();
        private readonly NotFound _notFoundRoute = new NotFound();
        private readonly RouteManager _routeManager = new RouteManager();

        public GroupRoute Group(string prefix)
        {
            var group = new GroupRoute(prefix);
            _routeManager.Add(group);

            return group;
        }

        public IRoute Add(string method, string name, string routePattern, RouteFuncAsync handler)
        {
            var route = new Route(method, name, routePattern, handler);
            _routeManager.Add(route);

            return route;
        }

        public async Task HandleAsync(Request request, IResponse response)
        {
            var requestHandler = GetRequestHandler(request, response) ??
                                 _notFoundRoute.GetRequestHandler(request, response);
            await requestHandler.RunAsync(requestHandler.GetContext(request, response));
        }

        public void Use(RouteFuncAsyncMiddleware middlewareFunc)
        {
            _middlewareManager.Use(middlewareFunc);
        }

        private IRequestHandler GetRequestHandler(Request request, IResponse response)
        {
            var requestHandler = _routeManager.FindRoute(request, response);
            return requestHandler != null
                ? new MiddlewareRequestHandler(_middlewareManager.GetRuntime(requestHandler.RunAsync),
                    requestHandler.GetContext(request, response))
                : null;
        }
    }
}