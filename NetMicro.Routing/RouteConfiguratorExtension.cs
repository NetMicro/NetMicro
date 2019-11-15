namespace NetMicro.Routing
{
    public static class RouteConfiguratorExtension
    {
        public static IRoute Get(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("GET", name, path, handler);
        }

        public static IRoute Head(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("HEAD", name, path, handler);
        }

        public static IRoute Post(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("POST", name, path, handler);
        }

        public static IRoute Put(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("PUT", name, path, handler);
        }

        public static IRoute Delete(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("DELETE", name, path, handler);
        }

        public static IRoute Connect(this IRouteConfigurator routeConfigurator, string name,
            string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("CONNECT", name, path, handler);
        }

        public static IRoute Options(this IRouteConfigurator routeConfigurator, string name,
            string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("OPTIONS", name, path, handler);
        }

        public static IRoute Trace(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("TRACE", name, path, handler);
        }

        public static IRoute Patch(this IRouteConfigurator routeConfigurator, string name, string path,
            RouteFuncAsync handler)
        {
            return routeConfigurator.Add("PATCH", name, path, handler);
        }
    }
}