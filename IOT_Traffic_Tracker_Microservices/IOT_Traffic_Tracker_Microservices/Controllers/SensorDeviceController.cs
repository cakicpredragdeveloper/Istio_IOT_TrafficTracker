using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensor_Device_Service.Helpers;


namespace Sensor_Device_Service.Controllers
{
    [ApiController]
    [Route("sensor-device-service")]
    public class SensorDeviceController : Controller
    {
        public SensorDeviceController()
        {
            
        }

        //TODO: POST ruta za postavljanje time limit-a

        [HttpPost("time-limit")]
        public IActionResult SetTimeLimit([FromBody] int newTimeLimit)
        {
            object lockObject = new object();

            lock(lockObject)
            {
                DeviceParameters.TimeLimit = newTimeLimit;
            }

            return Ok("Time limit is set successfully");
        }

        [HttpGet("time-limit")]
        public IActionResult GetTimeLimit()
        {
            object lockObject = new object();
            int result;
            lock (lockObject)
            {
                result = DeviceParameters.TimeLimit;
            }

            return Ok(result);
        }

        [HttpPost("ammount-of-data")]
        public IActionResult SetAmmountOfData([FromBody] int newAmmountOfData)
        {
            object lockObject = new object();

            lock (lockObject)
            {
                DeviceParameters.AmmountOfData = newAmmountOfData;
            }

            return Ok("Ammount of data is set successfully");
        }

        [HttpGet("ammount-of-data")]
        public IActionResult GetAmmountOfData()
        {
            object lockObject = new object();
            int result;
            lock (lockObject)
            {
                result = DeviceParameters.AmmountOfData;
            }

            return Ok(result);
        }
    }
}
