using Basic.Contract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basic.Controllers
{


    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }



        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }


        public async Task<IActionResult> Authenticate()
        {
            var grandmaClaims = new []
            {                             
                new Claim(ClaimTypes.Name,"CookieGrandma"),
                new Claim(ClaimTypes.Email,"Bob@gmail.com"),
                new Claim(ClaimTypes.GivenName,"Bob"),
                new Claim(ClaimTypes.Role,"Admin"),
            };


            var licenseClaims = new[]
{
                new Claim(ClaimTypes.Name,"Bob King"),
                new Claim(ClaimTypes.Country,"Israel"),
                new Claim(ClaimTypes.Role,"Admin"),
            };


            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincpal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity }) ;

          await  HttpContext.SignInAsync(userPrincpal);



            return RedirectToAction("Index");
        }

    }
}
