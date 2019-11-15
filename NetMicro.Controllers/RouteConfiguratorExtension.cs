using NetMicro.Routing;

namespace NetMicro.Controllers
{
    public static class RouteConfiguratorExtension
    {
        public static IRoute Get<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("GET", name, path, controller.Execute);
        }

        public static IRoute Head<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("HEAD", name, path, controller.Execute);
        }

        public static IRoute Post<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("POST", name, path, controller.Execute);
        }

        public static IRoute Put<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("PUT", name, path, controller.Execute);
        }

        public static IRoute Delete<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("DELETE", name, path, controller.Execute);
        }

        public static IRoute Connect<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("CONNECT", name, path, controller.Execute);
        }

        public static IRoute Options<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("OPTIONS", name, path, controller.Execute);
        }

        public static IRoute Trace<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("TRACE", name, path, controller.Execute);
        }

        public static IRoute Patch<TRoute, TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRoute : IRoute where TRequestController : IRequestController
        {
            return routeConfigurator.Add("PATCH", name, path, controller.Execute);
        }
    }
}