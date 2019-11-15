using NetMicro.Routing;

namespace NetMicro.Controllers
{
    public static class RouteConfiguratorExtension
    {
        public static IRoute Get<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("GET", name, path, controller.Execute);
        }

        public static IRoute Head<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("HEAD", name, path, controller.Execute);
        }

        public static IRoute Post<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("POST", name, path, controller.Execute);
        }

        public static IRoute Put<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("PUT", name, path, controller.Execute);
        }

        public static IRoute Delete<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("DELETE", name, path, controller.Execute);
        }

        public static IRoute Connect<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("CONNECT", name, path, controller.Execute);
        }

        public static IRoute Options<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("OPTIONS", name, path, controller.Execute);
        }

        public static IRoute Trace<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("TRACE", name, path, controller.Execute);
        }

        public static IRoute Patch<TRequestController>(this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController> controller
        ) where TRequestController : IRequestController
        {
            return routeConfigurator.Add("PATCH", name, path, controller.Execute);
        }
    }
}