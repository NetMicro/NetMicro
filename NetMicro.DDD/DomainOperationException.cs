using System;

namespace NetMicro.DDD
{
    public class DomainOperationException : Exception
    {
        public DomainOperationException(AggregateId aggregateId, String message)
            : base(message)
        {
            AggregateId = aggregateId;
        }
	
        public AggregateId AggregateId { get; }
    }
}