using System.Threading.Tasks;

namespace NetMicro.Routing
{
    public delegate Task RouteFuncAsyncMiddleware(Context context, RouteFuncAsync next);
}