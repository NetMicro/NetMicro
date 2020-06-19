using System;

namespace NetMicro.DDD
{
    public abstract class BaseAggregateRoot
    {
        public enum AggregateStatus {
            Active, 
            Archive
        }
        
        protected readonly AggregateId _aggregateId;

        private Int64 _version;

        private AggregateStatus _aggregateStatus = AggregateStatus.Active;
	
        protected IDomainEventPublisher EventPublisher;

        protected BaseAggregateRoot(AggregateId aggregateId, long version)
        {
            _aggregateId = aggregateId;
            _version = version;
        }

        public void MarkAsRemoved() {
            _aggregateStatus = AggregateStatus.Archive;
        }

        public AggregateId => A
            return AggregateId;
        }

        public bool IsRemoved() {
            return _aggregateStatus == AggregateStatus.Archive;
        }
	
        protected void DomainError(String message) {
            throw new DomainOperationException(AggregateId, message);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;
            
            if (obj.GetType() == typeof(BaseAggregateRoot)) {
                BaseAggregateRoot other = (BaseAggregateRoot) obj;
                if (other.AggregateId == null)
                    return false;

                return other.AggregateId.Equals(AggregateId);
            }
		
            return false;
        }

        public override int GetHashCode()
        {
            return AggregateId.GetHashCode();
        }
    }
}