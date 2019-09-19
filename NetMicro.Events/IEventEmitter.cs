using System.Threading.Tasks;

namespace NetMicro.Events
{
    public interface IEventEmitter<in TEvent>
    {
        Task Emit(string eventName, TEvent data);
    }
}