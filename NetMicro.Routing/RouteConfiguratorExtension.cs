namespace NetMicro.Routing
{
    public static class RouteConfiguratorExtension
    {
        public static TRoute Get<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("GET", name, path, handler);
        }

        public static TRoute Head<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("HEAD", name, path, handler);
        }

        public static TRoute Post<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("POST", name, path, handler);
        }

        public static TRoute Put<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("PUT", name, path, handler);
        }

        public static TRoute Delete<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("DELETE", name, path, handler);
        }

        public static TRoute Connect<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name,
            string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("CONNECT", name, path, handler);
        }

        public static TRoute Options<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name,
            string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("OPTIONS", name, path, handler);
        }

        public static TRoute Trace<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("TRACE", name, path, handler);
        }

        public static TRoute Patch<TRoute>(this IRouteConfigurator<TRoute> routeConfigurator, string name, string path,
            RouteFuncAsync handler) where TRoute : IRoute
        {
            return routeConfigurator.Add("PATCH", name, path, handler);
        }
    }
}