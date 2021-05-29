using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Service.Services
{
    public class GeoService: IGeoService
    {
        public double AirDistance(double lat1, double lng1, double lat2, double lng2)
        {

            lng1 = (lng1 * Math.PI) / 180;
            lng2 = (lng2 * Math.PI) / 180;
            lat1 = (lat1 * Math.PI) / 180;
            lat2 = (lat2 * Math.PI) / 180;

            double dlng = lng2 - lng1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlng / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));
            double r = 6371;

            return (c * r);
        }
    }
}
