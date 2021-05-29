using Newtonsoft.Json;
using Sensor_Device_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Sensor_Device_Service.Services
{
    public class HttpService : IHttpService
    {
        public async Task<string> PostRequest(string url, SetOfTracks setOfSignals)
        {
            var json = JsonConvert.SerializeObject(setOfSignals);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}
