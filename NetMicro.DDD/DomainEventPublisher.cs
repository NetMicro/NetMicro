using System.Runtime.Serialization;

namespace NetMicro.DDD
{
    public interface IDomainEventPublisher
    {
        void Publish(ISerializable domainEvent);
    }
}