using System.Collections.Generic;

namespace NetMicro.LoadBalancing
{
    public interface ILoadBalancer<T> : ICollection<T>
    {
        void Update(T[] newItems);

        T Get();
    }
}