using NetMicro.Http;

namespace NetMicro.Routing
{
    public class GroupRoute : IRoute, IMiddlewareSupport, IRouteConfigurator<GroupRoute>
    {
        private readonly IMiddlewareManager _middlewareManager = new MiddlewareManager();
        private readonly string _prefix;

        private readonly RouteManager _routeManager = new RouteManager();

        public GroupRoute(string prefix)
        {
            _prefix = prefix.TrimEnd('/');
        }

        public void Use(RouteFuncAsyncMiddleware middlewareFunc)
        {
            _middlewareManager.Use(middlewareFunc);
        }

        public IRequestHandler GetRequestHandler(Request request, IResponse response)
        {
            var requestHandler = _routeManager.FindRoute(request, response);
            return requestHandler != null
                ? new MiddlewareRequestHandler(_middlewareManager.GetRuntime(requestHandler.RunAsync),
                    requestHandler.GetContext(request, response))
                : null;
        }

        public GroupRoute Add(string method, string name, string route, RouteFuncAsync handler)
        {
            _routeManager.Add(new Route(method, name, GetPrefixedRoute(route), handler));

            return this;
        }

        private string GetPrefixedRoute(string route)
        {
            return _prefix + "/" + route;
        }

        public GroupRoute Group(string route)
        {
            var group = new GroupRoute(GetPrefixedRoute(route));
            _routeManager.Add(group);

            return group;
        }
    }
}