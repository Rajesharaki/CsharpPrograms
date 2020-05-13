using Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IAccount
    {
        Task<IdentityResult> CreateUserAsync(RegisterViewModel model);
        Task<SignInResult> SignInAsync(LoginViewModel model);
        Task<string> ForgetPasswordAsync(ForgetPasswordViewModel model);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model);
        string SendMsgToMSMQ(string token);
        bool SendTokenToMail(string reciveMsg, string email);
        void LogoutAsync();
        AuthenticationProperties GoogleLogin(string provider,string url);
        Task<AuthenticationScheme> GetExternalAuthenticationSchemesAsync();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<SignInResult> ExternalLoginSignInAsync(ExternalLoginInfo info);
    }
}
