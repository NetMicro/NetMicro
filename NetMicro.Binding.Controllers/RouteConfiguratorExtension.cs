using NetMicro.Routing;

namespace NetMicro.Binding.Controllers
{
    public static class RouteConfiguratorExtension
    {
        public static IRoute Get<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("GET", name, path, controller.Execute);
        }

        public static IRoute Head<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("HEAD", name, path, controller.Execute);
        }

        public static IRoute Post<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("POST", name, path, controller.Execute);
        }

        public static IRoute Put<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("PUT", name, path, controller.Execute);
        }

        public static IRoute Delete<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("DELETE", name, path, controller.Execute);
        }

        public static IRoute Connect<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("CONNECT", name, path, controller.Execute);
        }

        public static IRoute Options<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("OPTIONS", name, path, controller.Execute);
        }

        public static IRoute Trace<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("TRACE", name, path, controller.Execute);
        }

        public static IRoute Patch<TRoute, TRequestController, TContent>(
            this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRoute : IRoute where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("PATCH", name, path, controller.Execute);
        }
    }
}