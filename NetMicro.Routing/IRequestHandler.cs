using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.Routing
{
    public interface IRequestHandler
    {
        Context GetContext(Request request, IResponse response);
        Task RunAsync(Context context);
    }
}