using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace NetMicro.Workers
{
    public class WorkersExtension : IExtension
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IEnumerable<IWorker> _workers;

        public WorkersExtension(
            IHostApplicationLifetime applicationLifetime,
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