using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NetMicro.Http;

namespace NetMicro.Routing.Owin
{
    public class Response : IResponse
    {
        private readonly HttpContext _httpContext;

        public Response(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public HttpStatusCode StatusCode
        {
            set => _httpContext.Response.StatusCode = (int) value;
            get => (HttpStatusCode) _httpContext.Response.StatusCode;
        }

        public async Task WriteBodyAsync(string body)
        {
            await _httpContext.Response.WriteAsync(body);
        }

        public void SetHeader(string header, params string[] values)
        {
            _httpContext.Response.Headers.Add(header, new StringValues(values));
        }
    }
}