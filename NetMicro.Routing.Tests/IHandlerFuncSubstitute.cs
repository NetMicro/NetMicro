using System.Threading.Tasks;

namespace NetMicro.Routing.Tests
{
    public interface IHandlerFuncSubstitute
    {
        Task Handle(Context context);
    }
}