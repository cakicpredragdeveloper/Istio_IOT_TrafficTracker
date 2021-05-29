using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Sensor_Device_Service.Services
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}