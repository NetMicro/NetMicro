using System;

namespace NetMicro.Http.Rest
{
    public class ParamIsNotNumberException : Exception
    {
        public ParamIsNotNumberException(string param)
            : base($"Cannot convert {param} to number!")
        {
        }
    }
}