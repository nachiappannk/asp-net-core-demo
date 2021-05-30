using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Controllers
{
    [ApiController]
    [Route("ReadingDataFromRequest")]
    public class ReadingDataFromRequestController : ControllerBase
    {
        private readonly ILogger<ReadingDataFromRequestController> _logger;

        public ReadingDataFromRequestController(ILogger<ReadingDataFromRequestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("reading-header")]
        public string ReadHeader([FromHeader(Name = "HeaderName")] string ss, 
            [FromHeader(Name = "AnotherHeaderName")] string ss2)
        {
            return "The header value is " + ss + ss2;
        }

        [HttpPost("reading-body")]
        public string ReadBody([FromBody] RequestBody requestBody)
        {
            return $"The header value is name:{requestBody.Name} city:{requestBody.City}";
        }

        public class RequestBody 
        {
            public string Name { get; set; }
            public string City { get; set; }
        }

        [HttpPost("reading-path/{name}/{age:int}")]
        public string ReadPath(string name, int age)
        {
            age++;
            return $"The header value is name:{name} age:{age}";
        }


        [HttpGet("reading-query")]
        public string ReadQuery([FromQuery(Name="name")]string name, [FromQuery(Name = "age")] int age)
        {
            age++;
            return $"The header value is name:{name} age:{age}";
        }

    }
}
