using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Models
{
    public class SetOfTracks
    {
        public List<Track> Tracks { get; set; }
            = new List<Track>();
    }
}
