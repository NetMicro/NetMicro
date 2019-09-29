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
}