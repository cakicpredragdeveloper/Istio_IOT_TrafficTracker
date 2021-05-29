using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Service.Services
{
    public interface IGeoService
    {
        double AirDistance(double lat1, double lng1, double lat2, double lng2);
    }
}
