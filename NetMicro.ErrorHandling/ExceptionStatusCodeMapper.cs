using System;
using System.Collections.Generic;
using System.Net;

namespace NetMicro.ErrorHandling
{
    public class ExceptionStatusCodeMapper
    {
        private readonly IEnumerable<ExceptionStatusCode> _exceptionsStatusCodes;

        public ExceptionStatusCodeMapper(IEnumerable<ExceptionStatusCode> exceptionsStatusCodes)
        {
            _exceptionsStatusCodes = exceptionsStatusCodes;
        }

        public HttpStatusCode GetStatusCode(Exception exception)
        {
            foreach (var exceptionsStatusCode in _exceptionsStatusCodes)
            {
                if (exception.GetType().IsAssignableFrom(exceptionsStatusCode.ExceptionType))
                    return exceptionsStatusCode.HttpStatusCode;
            }
            
            return HttpStatusCode.InternalServerError;
        }
    }

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