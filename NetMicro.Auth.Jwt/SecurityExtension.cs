using System;
using Microsoft.Extensions.Logging;
using NetMicro.Auth.Jwt.Middleware;
using NetMicro.Http;
using NetMicro.Routing;

namespace NetMicro.Auth.Jwt
{
    public static class SecurityExtension
    {
        public static void EnableJwtSecurity(
            this IMiddlewareSupport middlewareSupport,
            ITokenDecoder<JwtToken> tokenDecoder,
            IDevelopmentConfiguration developmentConfiguration,
            ILogger logger,
            Func<Request, bool> excludeFilter = null
        )
        {
            if (!developmentConfiguration.DisableSecurity)
                middlewareSupport.JwtAuth(tokenDecoder, logger, excludeFilter);
        }
    }
}