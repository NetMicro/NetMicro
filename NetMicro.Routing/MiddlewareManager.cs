using System.Collections.Generic;

namespace NetMicro.Routing
{
    public class MiddlewareManager : IMiddlewareManager
    {
        private readonly IList<RouteFuncAsyncMiddleware> _middleware = new List<RouteFuncAsyncMiddleware>();

        public MiddlewareRuntime GetRuntime(RouteFuncAsync handlerFunc)
        {
            return new MiddlewareRuntime(_middleware, handlerFunc);
        }

        public void Use(RouteFuncAsyncMiddleware middlewareFunc)
        {
            _middleware.Add(middlewareFunc);
        }
    }
}