using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace NetMicro.Queues.Kafka
{
    public class Producer<TMessage> : IProducer<TMessage>
    {
        private readonly ProducerConfig _config;

        public Producer(ProducerConfig config)
        {
            _config = config;
        }

        public async Task Produce(string topic, TMessage message)
        {
            try
            {
                using (var p = new ProducerBuilder<Null, string>(_config).Build())
                {
                    try
                    {
                        var dr = await p.ProduceAsync(topic,
                            new Message<Null, string> {Value = JsonConvert.SerializeObject(message)});
                        Console.WriteLine(dr.Status);
                    }
                    catch (ProduceException<Null, TMessage> e)
                    {
                        throw new ProducerException(e.Error.Reason);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}