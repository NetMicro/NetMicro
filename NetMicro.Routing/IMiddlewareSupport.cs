namespace NetMicro.Routing
{
    public interface IMiddlewareSupport
    {
        void Use(RouteFuncAsyncMiddleware middlewareFunc);
    }
}