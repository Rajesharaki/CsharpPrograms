using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Manager
{
    /// <summary>
    /// IAccountImplementation class implementing IAccount interfacce
    /// </summary>
    public class IAccountImplementation : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="usermanager">Inject UserManager Manadatory</param>
        /// <param name="signInManager">Inject SignInManager Mandatory</param>
        public IAccountImplementation(UserManager<IdentityUser> usermanager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// ChangePasswordAsync Method
        /// </summary>
        /// <param name="model">ChangePasswordAsync</param>
        /// <returns>IdentityResult</returns>
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            //Find user By using Email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            }
            return null;

        }

        /// <summary>
        /// CreateUserAsync Method
        /// </summary>
        /// <param name="model">RegisterViewModel mandatory</param>
        /// <returns>IdentityResult</returns>
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

        /// <summary>
        /// ForgetPasswordAsync Method
        /// </summary>
        /// <param name="model">ForgetPasswordViewMOdel</param>
        /// <returns>ResetPasswordToken</returns>
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

        /// <summary>
        /// ResetPasswordAsync Method
        /// </summary>
        /// <param name="model">ResetPasswordViewModel</param>
        /// <returns></returns>
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

        /// <summary>
        /// SignInAsync Method
        /// </summary>
        /// <param name="model">LoginViewModel</param>
        /// <returns>SignInResult</returns>
        public async Task<SignInResult> SignInAsync(LoginViewModel model)
        {

            return await _signInManager.PasswordSignInAsync(model.Email, model.Password,isPersistent:model.RememberMe,false);
        }
    }
}
