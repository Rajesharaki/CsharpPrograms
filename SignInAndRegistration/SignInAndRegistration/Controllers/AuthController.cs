using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SignInAndRegistration.ViewModel;

namespace SignInAndRegistration.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser>usermanager,IConfiguration configuration)
        {
            _usermanager = usermanager;
            _configuration = configuration;
        }
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody]RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _usermanager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //Genarate Email Token
                var emailtoken =await _usermanager.GenerateEmailConfirmationTokenAsync(user);
                //Genarate ConfiramationLink for email
                var confirmationlink = Url.Action("Confirmation", "Auth", new
                {
                    id=user.Id,
                    token = emailtoken
                },Request.Scheme);
            }
            return Ok(new { token = user.UserName });
        }
        public void Confirmation()
        {

        }
        [HttpPost("Login")]
        public async Task<ActionResult>Login([FromBody]LoginViewModel model)
        {
            var user = await _usermanager.FindByNameAsync(model.Username);
            if (user != null && await _usermanager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName)
                };
                var signingKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
                var expiryInMinutes = Convert.ToInt32(_configuration["JWT:ExpiryInMinutes"]);

                var Token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Site"],
                    audience: _configuration["JWT:Site"],
                    expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(Token),
                        expiration = Token.ValidTo
                    });
            }
            return Unauthorized();
        }
    }
}