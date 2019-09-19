namespace NetMicro.Routing
{
    public interface IRouteConfigurator<out TRoute> where TRoute : IRoute
    {
        TRoute Add(string method, string name, string route, RouteFuncAsync handler);
    }
}