namespace NetMicro.Routing
{
    public interface IMiddleware
    {
        void Use(RouteFuncAsyncMiddleware middlewareFunc);
    }
}