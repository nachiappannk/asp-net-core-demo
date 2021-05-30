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
        private ObjectTwo objectTwo;
        private ObjectOne objectOne;

        public UnderstandingDependencyController(ObjectOne objectOne, ObjectTwo objectTwo)
        {
            this.objectTwo = objectTwo;
            this.objectOne = objectOne;
        }


        [HttpGet("some-method")]
        public List<string> ReadHeader()
        {
            var result = new List<string>() {
                objectOne.GetResult(),
                objectTwo.GetResult(),
            };
            return result;
        }
    }



    public class ObjectOne
    {
        public ObjectOne(ObjectTwo objectTwo)
        {
            ObjectTwo = objectTwo;
        }

        public ObjectTwo ObjectTwo { get; }


        public string GetResult()
        {
            return $" objectone:hashcode:{this.GetHashCode()} -> objecttwo:hashcode:{this.ObjectTwo.GetHashCode()}";
        }
    }


    public class ObjectTwo
    {
        public string GetResult()
        {
            return $" objecttwo:hashcode:{this.GetHashCode()}";
        }
    }

}
