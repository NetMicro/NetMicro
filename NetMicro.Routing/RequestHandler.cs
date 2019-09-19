using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.Routing
{
    internal class RequestHandler : IRequestHandler
    {
        private readonly Context _context;
        private readonly RouteFuncAsync _handlerFunc;

        public RequestHandler(RouteFuncAsync handlerFunc, Context context)
        {
            _handlerFunc = handlerFunc;
            _context = context;
        }

        public Context GetContext(Request request, IResponse response)
        {
            return _context;
        }

        public async Task RunAsync(Context context)
        {
            await _handlerFunc(context);
        }
    }
}