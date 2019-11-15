namespace NetMicro.Routing
{
    public interface IRouteConfigurator
    {
        IRoute Add(string method, string name, string routePattern, RouteFuncAsync handler);
    }
}