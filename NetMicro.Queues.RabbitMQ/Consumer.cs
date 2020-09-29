using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NetMicro.Queues.RabbitMQ
{
    public class Consumer<TMessage> : IConsumer<TMessage>
    {
        private readonly IModel _channel;

        public Consumer(IModel channel)
        {
            _channel = channel;
        }

        public async Task Register(string topic, MessageReceived<TMessage> messageReceived)
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

                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = JsonConvert.DeserializeObject<TMessage>(Encoding.UTF8.GetString(body.ToArray()));
                        messageReceived(message);
                    };

                    _channel.BasicConsume(queue: topic,
                        autoAck: true,
                        consumer: consumer);
                }
                catch (Exception e)
                {
                    throw new ConsumerQueueException(e);
                }
            });
        }
    }
}