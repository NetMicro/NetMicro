using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

namespace NetMicro.Workers
{
    public class WorkersExtension : IExtension
    {
        private readonly IApplicationLifetime _applicationLifetime;
        private readonly IEnumerable<IWorker> _workers;

        public WorkersExtension(
            IApplicationLifetime applicationLifetime,
            IEnumerable<IWorker> workers)
        {
            _applicationLifetime = applicationLifetime;
            _workers = workers;
        }

        public void Extend()
        {
            foreach (var worker in _workers)
                _applicationLifetime.AddWorker(worker);
        }
    }
}