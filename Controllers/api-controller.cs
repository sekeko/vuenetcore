using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace vuenetcore.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("hello")]
        [HttpGet]
        public IActionResult Hello()
        {
            var msg = new { Message = "Hello SEKEKO World" };
            return this.Ok(msg);
        }
    }
}
