namespace NetMicro.Routing
{
    public interface IRouteConfigurator<out TRoute> where TRoute : IRoute
    {
        IRoute Add(string method, string name, string routePattern, RouteFuncAsync handler);
    }
}