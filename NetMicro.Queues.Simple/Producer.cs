using System.Threading.Tasks;

namespace NetMicro.Queues.Simple
{
    public class Producer<TMessage> : IProducer<TMessage>
    {
        private readonly Channel<TMessage> _channel;

        public Producer(Channel<TMessage> channel)
        {
            _channel = channel;
        }

        public async Task Produce(string topic, TMessage message)
        {
            await Task.Run(() => _channel.Publish(topic, message));
        }
    }
}