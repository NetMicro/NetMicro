using System.Threading.Tasks;

namespace NetMicro.Controllers
{
    public interface IRequestController
    {
        Task Execute();
    }
}