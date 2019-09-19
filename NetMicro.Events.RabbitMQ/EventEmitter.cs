using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace NetMicro.Events.RabbitMQ
{
    public class EventEmitter<TEvent> : IEventEmitter<TEvent>
    {
        private readonly IModel _channel;

        public EventEmitter(IModel channel)
        {
            _channel = channel;
        }

        public async Task Emit(string eventName, TEvent data)
        {
            await Task.Run(() =>
            {
                try
                {
                    _channel.ExchangeDeclare(eventName, ExchangeType.Fanout);
                    _channel.QueueDeclare(queue: eventName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

                    _channel.BasicPublish(exchange: eventName,
                        routingKey: "",
                        basicProperties: null,
                        body: body);
                }
                catch (Exception e)
                {
                    throw new EventEmitterException(e.Message);
                }
            });
        }
    }
}