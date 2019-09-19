using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace NetMicro.Queues.RabbitMQ
{
    public class Producer<TMessage> : IProducer<TMessage>
    {
        private readonly IModel _channel;

        public Producer(IModel channel)
        {
            _channel = channel;
        }

        public async Task Produce(string topic, TMessage message)
        {
            await Task.Run(() =>
            {
                try
                {
                    _channel.QueueDeclare(queue: topic,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    _channel.BasicPublish(exchange: "",
                        routingKey: topic,
                        basicProperties: null,
                        body: body);
                }
                catch (Exception e)
                {
                    throw new ProducerException(e.Message);
                }
            });
        }
    }
}