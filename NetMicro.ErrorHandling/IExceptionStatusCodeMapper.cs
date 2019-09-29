using System;
using System.Collections.Generic;
using System.Net;

namespace NetMicro.ErrorHandling
{
    public interface IExceptionStatusCodeMapper
    {
        HttpStatusCode GetStatusCode(Exception exception);
    }
}