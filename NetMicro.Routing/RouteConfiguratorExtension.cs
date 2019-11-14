namespace NetMicro.Routing
{
    public static class RouteConfiguratorExtension
    {
        public static IRoute Get<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("GET", name, path, handler);
        }

        public static IRoute Head<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("HEAD", name, path, handler);
        }

        public static IRoute Post<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("POST", name, path, handler);
        }

        public static IRoute Put<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("PUT", name, path, handler);
        }

        public static IRoute Delete<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("DELETE", name, path, handler);
        }

        public static IRoute Connect<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name,
            string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("CONNECT", name, path, handler);
        }

        public static IRoute Options<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name,
            string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("OPTIONS", name, path, handler);
        }

        public static IRoute Trace<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("TRACE", name, path, handler);
        }

        public static IRoute Patch<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("PATCH", name, path, handler);
        }
    }
}