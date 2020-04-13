using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Manager
{
    public class IAccountImplementation : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //Constrctor Dependency injection (Injecting Usermanager and SignInmanager)
        public IAccountImplementation(UserManager<IdentityUser> usermanager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        //CreateUserAsync Method
        public async Task<IdentityResult> CreateUserAsync(RegisterViewModel model)
        {
            //Create Identity User
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed=true
            };

            //create User
            return await this._userManager.CreateAsync(user, model.Password);
        }

        //ForgetPasswordAsync Method and it returns ResetPassword Token
        public async Task<string> ForgetPasswordAsync(ForgetPasswordViewModel model)
        {
            //Find User Email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.IsEmailConfirmedAsync(user))
            {
                //return Token
                return await _userManager.GeneratePasswordResetTokenAsync(user);
            }
            return null;
        }

        //ResetPasswordAsync Method
        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            //Find User by using Email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                //reset password
                return await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            }
            return null;
        }

        //SignInAsync Method
        public async Task<SignInResult> SignInAsync(LoginViewModel model)
        {

            return await _signInManager.PasswordSignInAsync(model.Email, model.Password,isPersistent:model.RememberMe,false);
        }
    }
}
