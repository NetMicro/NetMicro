using NetMicro.Auth.Jwt.Middleware;
using NetMicro.Routing;

namespace NetMicro.Auth.Jwt
{
    public static class SecurityExtension
    {
        public static void EnableJwtSecurity(
            this IMiddlewareSupport middlewareSupport,
            ITokenDecoder<JwtToken> tokenDecoder,
            IDevelopmentConfiguration developmentConfiguration
        )
        {
            if (!developmentConfiguration.DisableSecurity)
                middlewareSupport.JwtAuth(tokenDecoder);
        }
    }
}