using System.Collections.Generic;

namespace NetMicro.Routing
{
    public class SelectedRoute
    {
        public SelectedRoute(
            string routeName,
            string routePath,
            IDictionary<string, string> uriParams)
        {
            RouteName = routeName;
            RoutePath = routePath;
            UriParams = uriParams;
        }

        public IDictionary<string, string> UriParams { get; }
        public string RouteName { get; }
        public string RoutePath { get; }
    }
}