using Authentication.Dtos;
using Authentication.Models;
using Authentication.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var home = new HomeVM
            {
                signInManager = _signInManager,
                userManager = _userManager
            };
            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDtos loginDtos)
        {
            if (ModelState.IsValid)
            {
               var user = await  _userManager.FindByEmailAsync(loginDtos.Email);
               if (user == null && (await _userManager.CheckPasswordAsync(user,loginDtos.Password)))
                {
                    ModelState.AddModelError(string.Empty, "User Not Registered!");
                    return View();
                }
                var result = await _signInManager.PasswordSignInAsync(
                    loginDtos.Email,
                    loginDtos.Password,
                    loginDtos.IsRemember,
                    false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Admin", "Dashboard");
                }
                ModelState.AddModelError(string.Empty, "Invalid Eamil And Password!");
            }
            return View(loginDtos);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    UserName = registerDto.Email
                };

                var result  = await _userManager.CreateAsync(user,registerDto.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                } 
            }
            return View(registerDto);
        }
    }
}
