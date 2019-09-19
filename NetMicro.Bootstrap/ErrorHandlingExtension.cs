using NetMicro.Bootstrap.Config;
using NetMicro.ErrorHandling;
using NetMicro.Routing;

namespace NetMicro.Bootstrap
{
    public static class MiddlewareSupportExtension
    {
        public static void UseRestErrorHandling(
            this IMiddlewareSupport middlewareSupport,
            IDevelopmentConfiguration developmentConfiguration
        )
        {
            if (developmentConfiguration.ErrorHandling)
                middlewareSupport.RestHandleExceptions();
        }
    }
}