using NetMicro.ErrorHandling;
using NetMicro.Routing;

namespace NetMicro.Bootstrap
{
    public static class MiddlewareSupportExtensions
    {
        public static void UseRestErrorHandling(
            this IMiddlewareSupport middlewareSupport,
            IDevelopmentConfiguration developmentConfiguration, 
            ExceptionStatusCodeMapper exceptionStatusCodeMapper)
        {
            if (developmentConfiguration.ErrorHandling)
                middlewareSupport.RestHandleExceptions(exceptionStatusCodeMapper);
        }
    }
}