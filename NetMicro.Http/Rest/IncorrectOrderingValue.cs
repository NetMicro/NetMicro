using System;

namespace NetMicro.Http.Rest
{
    public class IncorrectOrderingValue : Exception
    {
        public IncorrectOrderingValue(string value)
            : base($"Value {value} is not correct ordering. Expected 'asc' or 'desc'")
        {
        }
    }
}