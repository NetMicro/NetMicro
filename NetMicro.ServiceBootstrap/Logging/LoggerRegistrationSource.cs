using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Delegate;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Microsoft.Extensions.Logging;

namespace NetMicro.ServiceBootstrap.Logging
{
    internal class LoggerRegistrationSource : IRegistrationSource
    {
        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service, 
            Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
        {
            var swt = service as IServiceWithType;
            if (swt == null || !swt.ServiceType.IsGenericType || swt.ServiceType.GetGenericTypeDefinition() != typeof(ILogger<>))
            {
                return Enumerable.Empty<IComponentRegistration>();
            }

            var registration = new ComponentRegistration(
                Guid.NewGuid(),
                new DelegateActivator(swt.ServiceType, (c, p) =>
                {
                    var loggerFactory = c.Resolve<ILoggerFactory>();

                    var methodInfo = typeof(LoggerFactoryExtensions)
                        .GetMethods(BindingFlags.Public | BindingFlags.Static)
                        .Single(mi => mi.Name == "CreateLogger" && mi.IsGenericMethod);

                    var method = methodInfo
                        .MakeGenericMethod(swt.ServiceType.GetGenericArguments()[0]);

                    return method.Invoke(loggerFactory, new object[]
                    {
                        loggerFactory
                    });
                }),
                new CurrentScopeLifetime(),
                InstanceSharing.None,
                InstanceOwnership.OwnedByLifetimeScope,
                new[] {service},
                new Dictionary<string, object>());

            return new IComponentRegistration[] {registration};
        }

        public bool IsAdapterForIndividualComponents => false;
    }
}