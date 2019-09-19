using System.Threading.Tasks;

namespace NetMicro.Routing.Tests
{
    public interface IMiddlewareSubstitute
    {
        Task Handle(Context context, RouteFuncAsync handlerFunc);
    }
}