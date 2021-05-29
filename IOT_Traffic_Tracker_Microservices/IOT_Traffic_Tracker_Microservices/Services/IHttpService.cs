using Sensor_Device_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Services
{
    public interface IHttpService
    {
        Task<string> PostRequest(string url, SetOfTracks setOfSignals);
    }
}
