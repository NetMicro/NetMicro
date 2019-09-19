using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NetMicro.Events.RabbitMQ
{
    public class EventReceiver<TEvent> : IEventReceiver<TEvent>
    {
        private readonly IModel _channel;

        public EventReceiver(IModel channel)
        {
            _channel = channel;
        }

        public async Task Register(string eventName, EventReceived<TEvent> messageReceived)
        {
            await Task.Run(() =>
            {
                try
                {
                    _channel.ExchangeDeclare(eventName, ExchangeType.Fanout);
                    
                    var queueName = _channel.QueueDeclare().QueueName;
                    _channel.QueueBind(queue: queueName,
                        exchange: eventName,
                        routingKey: "");

                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = JsonConvert.DeserializeObject<TEvent>(Encoding.UTF8.GetString(body));
                        messageReceived(message);
                    };

                    _channel.BasicConsume(queue: eventName,
                        autoAck: true,
                        consumer: consumer);
                }
                catch (Exception e)
                {
                    throw new EventReceiverException(e);
                }
            });
        }
    }
}