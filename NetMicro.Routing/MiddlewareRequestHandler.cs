using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.Routing
{
    internal class MiddlewareRequestHandler : IRequestHandler
    {
        private readonly Context _context;
        private readonly MiddlewareRuntime _middlewareRuntime;

        public MiddlewareRequestHandler(MiddlewareRuntime middlewareRuntime, Context context)
        {
            _middlewareRuntime = middlewareRuntime;
            _context = context;
        }

        public Context GetContext(Request request, IResponse response)
        {
            return _context;
        }

        public async Task RunAsync(Context context)
        {
            await _middlewareRuntime.Invoke(context);
        }
    }
}