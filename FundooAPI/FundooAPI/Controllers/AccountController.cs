using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount accountmanager;

        public AccountController(IAccount account)
        {
            accountmanager = account;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountmanager.CreateUserAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        Email = model.Email,
                        Msg = "Successfully created"
                    }); ;
                }
            }
            return BadRequest(
                new
                {
                    Email = model.Email,
                    Msg = "Registration Failed"
                });
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountmanager.SignInAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Msg = "Successfully Login"
                    }); ;
                }
            }
            return BadRequest(new
            {
                Email = model.Email,
                Password = model.Password,
                Msg = "Not Valid Email and Password"
            });
        }
        [HttpPost]
        [Route("Forget")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await accountmanager.ForgetPasswordAsync(model);
                var link = Url.Action("ResetPassword", "Account", new
                {
                    Email = model.Email,
                    token = token
                }, Request.Scheme);
                return Ok(new
                {
                    Token = link
                });
            }
            return BadRequest(
                new
                {
                    Email = model.Email,
                    Msg = "Invalid Email"
                });
        }
        [HttpPost]
        [Route("Reset")]
        public async Task<IActionResult> ResetPassword([FromHeader]string Email,
            [FromHeader]String token, ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ResetPasswordViewModel resetmodel = new ResetPasswordViewModel
                {
                    Email = Email,
                    Token = token,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword
                };
                var result = await accountmanager.ResetPasswordAsync(resetmodel);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Msg = "Successfully Reset your password"
                    }); ;
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return BadRequest(new { str = "hello" });
        }
    }
}