using System.Threading.Tasks;

namespace NetMicro.Events.Simple
{
    public class EventEmitter<TEvent> : IEventEmitter<TEvent>
    {
        private readonly Channel<TEvent> _channel;

        public EventEmitter(Channel<TEvent> channel)
        {
            _channel = channel;
        }

        public async Task Emit(string eventName, TEvent data)
        {
            await Task.Run(() => _channel.Publish(eventName, data));
        }
    }
}