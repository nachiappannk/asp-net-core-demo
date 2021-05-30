using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Controllers
{
    [ApiController]
    [Route("ReadingDataFromRequest")]
    public class UnderstandingDependencyController : ControllerBase
    {
        public UnderstandingDependencyController()
        {

        }


        [HttpGet("some-method")]
        public string ReadHeader()
        {
            return "Some string";
        }
    }



    public class ObjectOne
    {
        public ObjectOne(ObjectTwo objectTwo)
        {
            ObjectTwo = objectTwo;
        }

        public ObjectTwo ObjectTwo { get; }
    }


    public class ObjectTwo
    {

    }

}
