namespace NetMicro.Routing
{
    public interface IMiddlewareManager : IMiddlewareSupport
    {
        MiddlewareRuntime GetRuntime(RouteFuncAsync handlerFunc);
    }
}