using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace FundooAPI.Controllers
{
    /// <summary>
    /// Account controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount accountmanager;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache distributedCache;

        /// <summary>
        /// constractor Dependency injection
        /// </summary>
        /// <param name="account">IAccount interface inject</param>
        /// <param name="configuration">IConfiguration interface inject</param>
        /// <param name="distributedCache">IDistributedCache interface inject</param>

        public AccountController(IAccount account, IConfiguration configuration, IDistributedCache distributedCache)
        {
            accountmanager = account;
            _configuration = configuration;
            this.distributedCache = distributedCache;
        }

        /// <summary>
        /// Register Post Method
        /// </summary>
        /// <param name="model">RegisterviewModel</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel model)
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

        /// <summary>
        /// Login Post Method
        /// </summary>
        /// <param name="model">LoginViewModel</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                //Calling IAccount Async SignInAsync Method and Passing Login view Model
                var result = await accountmanager.SignInAsync(model);
                if (result.Succeeded)
                {
                    var claim = new[] { new Claim(JwtRegisteredClaimNames.UniqueName, model.Email) };
                    var SignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SignInKey"]));
                    var ExpiryInMinutes = Convert.ToInt32(_configuration["JWT:ExpiryInMinutes"]);
                    var Token = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audiance"],
                        expires: DateTime.Now.AddMinutes(ExpiryInMinutes),
                        signingCredentials: new SigningCredentials(SignInKey, SecurityAlgorithms.HmacSha256),
                        claims: claim
                        );
                    var FinalToken = new JwtSecurityTokenHandler().WriteToken(Token);
                    return Ok(new
                    {
                        Email = model.Email,
                        Msg = "Successfully Login",
                        ExpiryInMinutes = ExpiryInMinutes,
                        token = FinalToken
                    });
                }
                return NotFound(new { Msg = "Login Failed please check your Email and Password" });
            }
            return BadRequest(new
            {
                Email = model.Email,
                Password = model.Password,
                Msg = "Not Valid Email and Password"
            });
        }

        /// <summary>
        /// ForgetPassword Post method
        /// </summary>
        /// <param name="model">ForgetPasswordViewModel</param>
        /// <returns>IActionResult Reset Token</returns>
        [HttpPost]
        [Route("Forget")]
        public async Task<IActionResult> ForgetPassword([FromForm]ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*Calling IAccount Async ForgetPasswordAsync Method and Passing Register view Model
                and its return Token*/
                var token = await accountmanager.ForgetPasswordAsync(model);
                var ReciveMsg=accountmanager.SendMsgToMSMQ(token);
                var result = accountmanager.SendTokenToMail(token, model.Email);
                return Ok(new
                {
                    Status = "Check your Mail"
                });
            }
            return BadRequest(
                new
                {
                    Email = model.Email,
                    Msg = "Invalid Email"
                });
        }

        /// <summary>
        /// ResetPassword Post Method
        /// </summary>
        /// <param name="model">ResetPasswordViewModel</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Reset")]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordViewModel model)
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

        /// <summary>
        /// ChangePassword Post Method
        /// </summary>
        /// <param name="model">ChangePasswordViewModel</param>
        /// <returns>IActionResult</returns>        
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromForm]ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountmanager.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new { Status = "Successfully changed your password" });
                }
            }
            return BadRequest(new { Status = "Failed" });
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
             accountmanager.LogoutAsync();
            return Ok( new {Status="Successfully Logout"});
        }

        /// <summary>
        /// Login with google
        /// </summary>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle()
        {
            var redirectUrl = Url.Action("ExternalCallBack", "Account");
            var provider = await this.accountmanager.GetExternalAuthenticationSchemesAsync();
            var properties = this.accountmanager.GoogleLogin(provider.Name, redirectUrl);
            return new ChallengeResult(provider.Name, properties);
        }

        [HttpPost, Route("ExternalCallBack")]
        public async Task<IActionResult> ExternalCallBack(string returnUrl, string remoteError)
        {
             if(returnUrl!=null && remoteError== null)
            {
                var result = await this.accountmanager.GetExternalLoginInfoAsync();
                if(result!=null)
                {
                    var SignInResult =await this.accountmanager.ExternalLoginSignInAsync(result);
                    if(SignInResult.Succeeded)
                    {
                        return this.Ok("login Successfull");
                    }
                }
            }
            return this.BadRequest("Failed logging in");
        }
    }
}