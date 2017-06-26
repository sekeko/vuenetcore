using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace vuenetcore.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("hello")]
         [Authorize]  
        [HttpGet]
        public IActionResult Hello()
        {
            var msg = new { Message = "Hello SEKEKO World" };
            return this.Ok(msg);
        }
         [Route("login")]
        [HttpGet]
        public IActionResult login()
        {
                 var identity = new ClaimsIdentity("password");
                 identity.AddClaim(new Claim(ClaimTypes.Name, "DefaultUser"));
                 identity.AddClaim(new Claim("Read", "true"));
                 
                 identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                 identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                 HttpContext.Authentication.SignInAsync("CustomAuth", new ClaimsPrincipal(identity)).Wait();
            var msg = new { Message = "You are log in!" };
            return this.Ok(msg);
        }
           [Route("logout")]
        [HttpGet]
        public IActionResult logout()
        {
            HttpContext.Authentication.SignOutAsync("CustomAuth").Wait();
            var msg = new { Message = "You are log out!" };
            return this.Ok(msg);
        }
    }
}
