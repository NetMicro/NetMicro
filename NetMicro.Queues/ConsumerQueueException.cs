using System;

namespace NetMicro.Queues
{
    public class ConsumerQueueException : Exception
    {
        public ConsumerQueueException(Exception exception) :
            base("", exception)
        {
        }
    }
}