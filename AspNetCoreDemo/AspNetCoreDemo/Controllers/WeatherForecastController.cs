using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/reading-header")]
        public string ReadHeader([FromHeader(Name = "HeaderName")] string ss, 
            [FromHeader(Name = "AnotherHeaderName")] string ss2)
        {
            return "The header value is " + ss + ss2;
        }

        [HttpPost("/reading-body")]
        public string ReadBody([FromBody] RequestBody requestBody)
        {
            return $"The header value is name:{requestBody.Name} city:{requestBody.City}";
        }

        public class RequestBody 
        {
            public string Name { get; set; }
            public string City { get; set; }
        }



        [HttpPost("/reading-path/{name}/{age:int}")]
        public string ReadPath(string name, int age)
        {
            age++;
            return $"The header value is name:{name} age:{age}";
        }
    }
}
