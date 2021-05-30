using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Controllers
{

    [ApiController]
    [Route("Output")]
    public class OutputController : ControllerBase
    {
        [HttpGet("write-header")]
        public string AddHeader()
        {
            HttpContext.Response.Headers.Add("header-name", "header-value");
            return "result";
        }


        [HttpGet("set-status-code")]
        public string ChangeStatusCode()
        {
            HttpContext.Response.StatusCode = 207;
            return "result";
        }


        [HttpGet("set-status-code1")]
        public ActionResult<string> ChangeStatusCode1()
        {
            return StatusCode(209, "result");
        }


        [HttpGet("write-body")]
        public void WriteBody()
        {
            byte[] data = Encoding.UTF8.GetBytes("output");
            Response.Body.WriteAsync(data, 0, data.Length).Wait();
        }
    }
}
