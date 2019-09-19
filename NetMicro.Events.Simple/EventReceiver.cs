using System.Threading.Tasks;

namespace NetMicro.Events.Simple
{
    public class EventReceiver<TEvent> : IEventReceiver<TEvent>
    {
        private readonly Channel<TEvent> _channel;

        public EventReceiver(Channel<TEvent> channel)
        {
            _channel = channel;
        }

        public Task Register(string eventName, EventReceived<TEvent> eventReceived)
        {
            return Task.Run(() => _channel.AddReceiver(eventName, eventReceived));
        }
    }
}