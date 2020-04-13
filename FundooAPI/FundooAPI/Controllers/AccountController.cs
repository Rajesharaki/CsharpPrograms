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

        //Constructor Dependency injection (Injecting IAcount Interface)
        public AccountController(IAccount account)
        {
            accountmanager = account;
        }

        //Register Post Method
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Calling IAccount Async CreateUserAsync Method and Passing Register view Model
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

        //Login Post Method
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Calling IAccount Async SignInAsync Method and Passing Login view Model
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

        //ForgetPassword Post Method and it returns PasswordResetToken
        [HttpPost]
        [Route("Forget")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*Calling IAccount Async ForgetPasswordAsync Method and Passing Register view Model
                and its return Token*/
                var token = await accountmanager.ForgetPasswordAsync(model);
                return Ok(new
                {
                    Email=model.Email,
                    Token = token
                }) ;
            }
            return BadRequest(
                new
                {
                    Email = model.Email,
                    Msg = "Invalid Email"
                });
        }

        //ResetPassword Post Method 
        [HttpPost]
        [Route("Reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Calling IAccount Async ReserPasswordAsync Method
                var result = await accountmanager.ResetPasswordAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Msg = "Successfully Reset your password"
                    }); ;
                }
            }
            return BadRequest(new { str = "Failed" });
        }
    }
}