using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Services
{
    public class BackgroundDataReader: IHostedService
    {
        private readonly ILogger<BackgroundDataReader> _logger;
        private readonly IWorker _worker;

        public BackgroundDataReader(ILogger<BackgroundDataReader> logger, IWorker worker)
        {
            _logger = logger;
            _worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker starting!");
            await _worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker stopping!");
            return Task.CompletedTask;
        }
    }
}
