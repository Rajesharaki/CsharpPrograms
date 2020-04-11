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

        public IAccountImplementation(UserManager<IdentityUser> usermanager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterViewModel model)
        {

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            return await this._userManager.CreateAsync(user, model.Password);
        }

        public async Task<string> ForgetPasswordAsync(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.IsEmailConfirmedAsync(user))
            {
                return await _userManager.GeneratePasswordResetTokenAsync(user);
            }
            return null;
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            }
            return null;
        }

        public async Task<SignInResult> SignInAsync(LoginViewModel model)
        {

            return await _signInManager.PasswordSignInAsync(model.Email, model.Password,isPersistent:model.RememberMe,false);
        }
    }
}
