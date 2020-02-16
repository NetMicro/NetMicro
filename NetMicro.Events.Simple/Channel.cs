using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetMicro.Events.Simple
{
    public class Channel
    {
        private static readonly IDictionary<string, IList<EventReceived<string>>> Receivers = new Dictionary<string, IList<EventReceived<string>>>();
        private readonly object _mutex = new object();

        public void AddReceiver<TEvent>(string eventName, EventReceived<TEvent> eventReceived)
        {
            if (!Receivers.Keys.Contains(eventName))
            {
                lock (_mutex)
                {
                    if (!Receivers.Keys.Contains(eventName))
                    {
                        Receivers.Add(eventName, new List<EventReceived<string>>());
                    }
                }
            }

            Receivers[eventName].Add(payload => eventReceived(JsonConvert.DeserializeObject<TEvent>(payload)));
        }

        public void Publish<TEvent>(string eventName, TEvent data)
        {
            if (Receivers.Keys.Contains(eventName))
            {
                Task[] tasks = null;

                lock (_mutex)
                {
                    tasks = new Task[Receivers[eventName].Count];
                    for (int i = 0; i < Receivers[eventName].Count; i++)
                        tasks[i] = Receivers[eventName][i](JsonConvert.SerializeObject(data));
                }

                Task.WaitAll(tasks);
            }
        }
    }
}