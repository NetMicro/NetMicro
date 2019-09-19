using System;

namespace NetMicro.Events
{
    public class EventEmitterException : Exception
    {
        public EventEmitterException(string reason) : base(reason)
        {
        }
    }
}