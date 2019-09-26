using System.Collections.Generic;

namespace NetMicro.Queues.Simple
{
    public class Channel<TMessage>
    {
        private readonly IDictionary<string, ObjectPool<MessageReceived<TMessage>>> _receivers = new Dictionary<string, ObjectPool<MessageReceived<TMessage>>>();
        private readonly object _mutex = new object();

        public void AddReceiver(string topic, MessageReceived<TMessage> messageReceived)
        {
            if (!_receivers.Keys.Contains(topic))
            {
                lock (_mutex)
                {
                    if (!_receivers.Keys.Contains(topic))
                        _receivers.Add(topic, new ObjectPool<MessageReceived<TMessage>>(new[] { messageReceived }));                    
                }
            }
                    
            _receivers[topic].Add(messageReceived);
        }

        public void Publish(string topic, TMessage message)
        {
            if (_receivers.Keys.Contains(topic))
                _receivers[topic].Get()(message);
        }
    }
}