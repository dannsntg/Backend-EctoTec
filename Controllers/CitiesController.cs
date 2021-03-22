using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecto_TecBE.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string url = "http://api.geonames.org/searchJSON?formatted=true&username=dannsant123&style=full";
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);

            List<String> cities = new List<string>();

            foreach (var item in m.geonames)
            {
                string stringComplete = item.name + ", " + item.adminName1 + ", " + item.countryName;
                cities.Add(stringComplete);
            }

            return Ok(cities);
        }
    }
}
