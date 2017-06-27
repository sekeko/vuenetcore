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
            return new ObjectResult("Welcome to my world!");
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
                 return new ObjectResult("true");
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult logout()
        {
            HttpContext.Authentication.SignOutAsync("CustomAuth").Wait();
            return new ObjectResult("Logout!");
        }
    }
}
