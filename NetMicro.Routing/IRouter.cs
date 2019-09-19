using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.Routing
{
    public interface IRouter : IMiddlewareSupport, IRouteConfigurator<Route>
    {
        GroupRoute Group(string prefix);
        Task HandleAsync(Request request, IResponse response);
    }
}