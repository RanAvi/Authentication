using IdentityExample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{

    

    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public  async Task< IActionResult> Login(UserLogin userLogin)
        {

            var user = await _userManager.FindByNameAsync(userLogin.UserName);

            if(user != null)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user, userLogin.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

           
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async  Task<IActionResult> Register( UserLogin userLogin)
        {

            //info
            var user = new IdentityUser();
            user.UserName = userLogin.UserName;


            //
             var result=  await _userManager.CreateAsync(user,userLogin.Password);


            if (result.Succeeded)
            {
                //sign user here
                var signInResult = await _signInManager.PasswordSignInAsync(user, userLogin.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }



            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
               await  _signInManager.SignOutAsync();

               return RedirectToAction("Index");
        }
    }
  }
