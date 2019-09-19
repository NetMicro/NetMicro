using System.Threading.Tasks;

namespace NetMicro.Binding.Controllers
{
    public interface IRequestController<TContent>
    {
        Task Execute(TContent content);
    }
}