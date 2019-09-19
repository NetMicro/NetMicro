using System.Threading.Tasks;

namespace NetMicro.Queues
{
    public delegate Task MessageReceived<in TMessage>(TMessage message);
}