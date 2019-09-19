using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMicro.Events.Simple
{
    public class Channel<TEvent>
    {
        private readonly IDictionary<string, IList<EventReceived<TEvent>>> _receivers = new Dictionary<string, IList<EventReceived<TEvent>>>();
        private readonly object _mutex = new object();

        public void AddReceiver(string eventName, EventReceived<TEvent> eventReceived)
        {
            if (!_receivers.Keys.Contains(eventName))
            {
                lock (_mutex)
                {
                    if (!_receivers.Keys.Contains(eventName))
                    {
                        _receivers.Add(eventName, new List<EventReceived<TEvent>>());                        
                    }                    
                }
            }
            
            _receivers[eventName].Add(eventReceived);
        }

        public void Publish(string eventName, TEvent data)
        {
            if (_receivers.Keys.Contains(eventName))
            {
                Task[] tasks = null;

                lock (_mutex)
                {
                    tasks = new Task[_receivers[eventName].Count];
                    for (int i = 0; i < _receivers[eventName].Count; i++)
                        tasks[i] = _receivers[eventName][i](data);
                }

                Task.WaitAll(tasks);
            }
        }
    }
}