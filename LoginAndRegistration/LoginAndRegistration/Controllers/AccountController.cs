using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _usermanager;
        private SignInManager<IdentityUser> _signinmanager;

        public AccountController(UserManager<IdentityUser>usermanager,
            SignInManager<IdentityUser>signInManager )
        {
            _usermanager = usermanager;
            _signinmanager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModelView model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result=await _usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signinmanager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinmanager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Home");
                }
                ModelState.AddModelError("", "Invalid Login attempt");
            }
            return View(model);
        }
    }
}