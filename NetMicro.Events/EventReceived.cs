using System.Threading.Tasks;

namespace NetMicro.Events
{
    public delegate Task EventReceived<in TEvent>(TEvent data);
}