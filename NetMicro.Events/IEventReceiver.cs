using System.Threading.Tasks;

namespace NetMicro.Events
{
    public interface IEventReceiver<out TEvent>
    {
        Task Register(string eventName, EventReceived<TEvent> eventReceived);
    }
}