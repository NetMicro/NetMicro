using System;
using System.Net;
using Autofac;

namespace NetMicro.ErrorHandling.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseErrorHandling(this ContainerBuilder builder)
        {
            builder.RegisterModule<ErrorHandlingModule>();
        }
        
        public static void RegisterExceptionStatusCode(this ContainerBuilder builder, Type exceptionType, HttpStatusCode statusCode)
        {
            builder.Register(c => new ExceptionStatusCode(exceptionType, statusCode));
        }
    }
}