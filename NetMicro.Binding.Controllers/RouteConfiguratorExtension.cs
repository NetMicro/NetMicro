using NetMicro.Routing;

namespace NetMicro.Binding.Controllers
{
    public static class RouteConfiguratorExtension
    {
        public static TRoute Get<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("GET", name, path, controller.Execute);
        }

        public static TRoute Head<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("HEAD", name, path, controller.Execute);
        }

        public static TRoute Post<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("POST", name, path, controller.Execute);
        }

        public static TRoute Put<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("PUT", name, path, controller.Execute);
        }

        public static TRoute Delete<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("DELETE", name, path, controller.Execute);
        }

        public static TRoute Connect<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("CONNECT", name, path, controller.Execute);
        }

        public static TRoute Options<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("OPTIONS", name, path, controller.Execute);
        }

        public static TRoute Trace<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("TRACE", name, path, controller.Execute);
        }

        public static TRoute Patch<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("PATCH", name, path, controller.Execute);
        }
    }
}