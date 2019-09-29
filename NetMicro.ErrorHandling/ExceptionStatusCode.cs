using System;
using System.Net;

namespace NetMicro.ErrorHandling
{
    public class ExceptionStatusCode
    {
        public ExceptionStatusCode(Type exceptionType, HttpStatusCode httpStatusCode)
        {
            if (exceptionType.IsAssignableFrom(typeof(Exception)))
                throw new Exception($"{exceptionType} is not an exception");
            
            ExceptionType = exceptionType;
            HttpStatusCode = httpStatusCode;
        }

        public Type ExceptionType { get; }
        public HttpStatusCode HttpStatusCode { get; }
    }
}