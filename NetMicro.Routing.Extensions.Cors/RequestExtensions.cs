using NetMicro.Http;

namespace NetMicro.Routing.Extensions.Cors
{
    public static class RequestExtensions
    {
        public static bool IsCorsPreflight(this Request request)
        {
            return request.Method == "OPTIONS" &&
               request.Headers.ContainsKey("Access-Control-Request-Method") &&
               request.Headers.ContainsKey("Access-Control-Request-Headers") &&
               request.Headers.ContainsKey("Origin");
        }
    }
}