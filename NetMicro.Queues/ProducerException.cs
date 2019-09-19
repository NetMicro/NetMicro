using System;

namespace NetMicro.Queues
{
    public class ProducerException : Exception
    {
        public ProducerException(string reason) : base(reason)
        {
        }
    }
}