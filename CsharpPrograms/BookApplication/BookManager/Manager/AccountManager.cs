using BookManager.Interface;
using Comman;
using Comman.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;
using Experimental.System.Messaging;

namespace BookManager.Manager
{
    public class AccountManager : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="usermanager">Inject UserManager Manadatory</param>
        /// <param name="signInManager">Inject SignInManager Mandatory</param>
        public AccountManager(UserManager<IdentityUser> usermanager,
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
                EmailConfirmed = true
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

        public bool SendTokenToMail(string reciveMsg, string email)
        {
            var messageToSend = new MimeMessage
            {
                Sender = new MailboxAddress(email, email),
                Subject = "Reset your Password Token"
            };
            messageToSend.From.Add(new MailboxAddress(email, email));
            messageToSend.Body = new TextPart(TextFormat.Html) { Text = reciveMsg };
            messageToSend.To.Add(new MailboxAddress("rajesharaki8613@gmail.com"));
            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate("rajesharaki8613@gmail.com", "r9686454072");
            client.Send(messageToSend);
            client.Disconnect(true);
            return true;
        }

        public string SendMsgToMSMQ(string token)
        {
            //send token to the MSMQ
            MessageQueue messageQueue;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                messageQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }
            Message msg = new Message();
            messageQueue.Label = "Token";
            messageQueue.Send(token);

            //Retrive MSG from MSMQ in FIFO order

            var MsgQueue = new MessageQueue(@".\Private$\MyQueue");
            var message = MsgQueue.Receive();
            message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });
            var Msg = message.Body.ToString();
            return Msg;
        }

        /// <summary>
        /// SignInAsync Method
        /// </summary>
        /// <param name="model">LoginViewModel</param>
        /// <returns>SignInResult</returns>
        public async Task<SignInResult> SignInAsync(LoginViewModel model)
        {

            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        }

        public async void LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return;
        }
    }
}

