using NetMicro.Http;

namespace NetMicro.Routing
{
    public interface IRoute : IMiddlewareSupport
    {
        IRequestHandler GetRequestHandler(Request request, IResponse response);
    }
}