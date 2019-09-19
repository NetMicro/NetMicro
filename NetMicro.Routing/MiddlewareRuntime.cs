using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMicro.Routing
{
    public class MiddlewareRuntime
    {
        private readonly RouteFuncAsync _handlerFunc;

        private readonly Middleware _middleware;

        public MiddlewareRuntime(
            IEnumerable<RouteFuncAsyncMiddleware> routeFuncAsyncMiddlewareList,
            RouteFuncAsync handlerFunc
        )
        {
            _handlerFunc = handlerFunc;
            foreach (var routeFuncAsyncMiddleware in routeFuncAsyncMiddlewareList)
            {
                var middleware = new Middleware
                {
                    Next = context => _handlerFunc(context),
                    HandlerFunc = routeFuncAsyncMiddleware
                };

                if (_middleware == null)
                    _middleware = middleware;
                else
                    _middleware.Next = middleware.Invoke;
            }
        }

        public async Task Invoke(Context context)
        {
            if (_middleware != null)
                await _middleware.Invoke(context);
            else
                await _handlerFunc(context);
        }

        private class Middleware
        {
            public RouteFuncAsync Next { private get; set; }
            public RouteFuncAsyncMiddleware HandlerFunc { private get; set; }

            public async Task Invoke(Context context)
            {
                await HandlerFunc(context, Next);
            }
        }
    }
}