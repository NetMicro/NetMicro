using Microsoft.AspNetCore.Hosting;

namespace NetMicro.Workers
{
    public static class ApplicationLifetimeExtensions
    {
        public static void AddWorker(this IApplicationLifetime lifetime, IWorker worker)
        {
            if (!worker.IsEnabled)
                return;

            lifetime.ApplicationStarted.Register(worker.Start);
            lifetime.ApplicationStopping.Register(worker.Stop);
        }
    }
}