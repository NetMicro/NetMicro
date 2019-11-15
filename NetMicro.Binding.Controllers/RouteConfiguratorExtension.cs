using NetMicro.Routing;

namespace NetMicro.Binding.Controllers
{
    public static class RouteConfiguratorExtension
    {
        public static IRoute Get<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("GET", name, path, controller.Execute);
        }

        public static IRoute Head<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("HEAD", name, path, controller.Execute);
        }

        public static IRoute Post<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("POST", name, path, controller.Execute);
        }

        public static IRoute Put<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("PUT", name, path, controller.Execute);
        }

        public static IRoute Delete<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("DELETE", name, path, controller.Execute);
        }

        public static IRoute Connect<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("CONNECT", name, path, controller.Execute);
        }

        public static IRoute Options<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("OPTIONS", name, path, controller.Execute);
        }

        public static IRoute Trace<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("TRACE", name, path, controller.Execute);
        }

        public static IRoute Patch<TRequestController, TContent>(
            this IRouteConfigurator routeConfigurator,
            string name, string path,
            Controller<TRequestController, TContent> controller
        ) where TRequestController : IRequestController<TContent>
        {
            return routeConfigurator.Add("PATCH", name, path, controller.Execute);
        }
    }
}