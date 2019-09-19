using NetMicro.Http;

namespace NetMicro.Routing
{
    public interface IRoute
    {
        IRequestHandler GetRequestHandler(Request request, IResponse response);
    }
}