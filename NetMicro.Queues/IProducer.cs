using System.Threading.Tasks;

namespace NetMicro.Queues
{
    public interface IProducer<in TMessage>
    {
        Task Produce(string topic, TMessage message);
    }
}