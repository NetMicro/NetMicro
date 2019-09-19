using System.Threading.Tasks;

namespace NetMicro.Queues
{
    public interface IConsumer<out TMessage>
    {
        Task Register(string topic, MessageReceived<TMessage> messageReceived);
    }
}