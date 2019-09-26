using System.Threading.Tasks;

namespace NetMicro.Queues.Simple
{
    public class Consumer<TMessage> : IConsumer<TMessage>
    {
        private readonly Channel<TMessage> _channel;

        public Consumer(Channel<TMessage> channel)
        {
            _channel = channel;
        }

        public Task Register(string topic, MessageReceived<TMessage> messageReceived)
        {
            return Task.Run(() => _channel.AddReceiver(topic, messageReceived));
        }
    }
}