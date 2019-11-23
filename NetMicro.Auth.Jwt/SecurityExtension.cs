using System;
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
            Func<Request, bool> excludeFilter = null
        )
        {
            if (!developmentConfiguration.DisableSecurity)
                middlewareSupport.JwtAuth(tokenDecoder, excludeFilter);
        }
    }
}