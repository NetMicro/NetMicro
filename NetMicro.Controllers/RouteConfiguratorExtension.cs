using NetMicro.Routing;

namespace NetMicro.Controllers
{
    public static class RouteConfiguratorExtension
    {
        public static TRoute Get<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("GET", name, path, controller.Execute);
        }

        public static TRoute Head<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("HEAD", name, path, controller.Execute);
        }

        public static TRoute Post<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("POST", name, path, controller.Execute);
        }

        public static TRoute Put<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("PUT", name, path, controller.Execute);
        }

        public static TRoute Delete<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("DELETE", name, path, controller.Execute);
        }

        public static TRoute Connect<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("CONNECT", name, path, controller.Execute);
        }

        public static TRoute Options<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("OPTIONS", name, path, controller.Execute);
        }

        public static TRoute Trace<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("TRACE", name, path, controller.Execute);
        }

        public static TRoute Patch<TRoute, TRequestController>(this IRouteConfigurator<TRoute> routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("PATCH", name, path, controller.Execute);
        }
    }
}