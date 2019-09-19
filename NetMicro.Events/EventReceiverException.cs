using System;

namespace NetMicro.Events
{
    public class EventReceiverException : Exception
    {
        public EventReceiverException(Exception exception) :
            base("", exception)
        {
        }
    }
}