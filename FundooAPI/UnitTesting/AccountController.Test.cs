using BusinessManager.Interface;
using BusinessManager.Manager;
using Common.Models;
using FundooAPI.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace UnitTesting
{
    public class AccountControllerTest
    {
      
        [Fact]
        public async void RegisterActionReturnOk()
        {
            var accountservice = new Mock<IAccount>();
            accountservice.Setup(
                x => x.CreateUserAsync(It.IsAny<RegisterViewModel>())
                ).ReturnsAsync(IdentityResult.Success);
            var Configservice = new Mock<IConfiguration>();
            var DistrubutedCache = new Mock<IDistributedCache>();
            AccountController controller = new AccountController(accountservice.Object, Configservice.Object,DistrubutedCache.Object);
            //arrange
            RegisterViewModel model = new RegisterViewModel
            {
                Email = "111rajeshamadan@gmail.com",
                Password="Rr@9686454072",
                ConfirmPassword="Rr@9686454072"
            };

            //act
            var result=await controller.Register(model);
            var response= result as OkObjectResult;
            //assert
            Assert.NotNull(response);
            Assert.Equal(200,response.StatusCode);
        }

        [Fact]
        public async void RegisterActionReturnBadRequest()
        {
            var account = new Mock<IAccount>();
            account.Setup(p => p.CreateUserAsync(It.IsAny<RegisterViewModel>())).ReturnsAsync(IdentityResult.Failed());
            var config = new Mock<IConfiguration>();
            var DistrubutedCache = new Mock<IDistributedCache>();
            AccountController controller = new AccountController(account.Object, config.Object, DistrubutedCache.Object);
            var model = new RegisterViewModel();

            //act
            var result=await controller.Register(model);
            var response=result as BadRequestObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void LoginActionReturnOk()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.SignInAsync(It.IsAny<LoginViewModel>())).ReturnsAsync(SignInResult.Success);
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config)=>config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object,service1.Object, DistrubutedCache.Object);

            //arrange
            var model = new LoginViewModel
            {
                Email = "rajeshamadan2017@gmail.com",
                Password = "Rr@9686454072",
                RememberMe = true
            };

            //act
            var result = await controller.Login(model);
            var response=result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void LoginActionReturnBadRequest()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.SignInAsync(It.IsAny<LoginViewModel>())).ReturnsAsync(SignInResult.Success);
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config) => config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object, service1.Object, DistrubutedCache.Object);
            //arrange
            var model = new LoginViewModel
            {
                Email = "rajeshamadan2017@gmail.com",
                Password = "Rr@9686454072",
                RememberMe = true
            };

            //act
            var result = await controller.Login(model);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void ForgetPasswordReturnOk()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.ForgetPasswordAsync(It.IsAny<ForgetPasswordViewModel>())).ReturnsAsync((string token)=>token);
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config) => config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object, service1.Object, DistrubutedCache.Object);
            //arrange
            var model = new ForgetPasswordViewModel
            {
                Email="rajeshmadan@gmail.com"
            };

            //act
            var result = await controller.ForgetPassword(model);
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void ForgetPasswordReturnNotFound()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.ForgetPasswordAsync(It.IsAny<ForgetPasswordViewModel>())).ReturnsAsync((string token) => token);
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config) => config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object, service1.Object, DistrubutedCache.Object);
            //arrange
            var model = new ForgetPasswordViewModel
            {
                Email = "rajesh@gmail.com"
            };

            //act
            var result = await controller.ForgetPassword(model);
            var response = result as NotFoundObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        Object Token;
        [Fact]
        public async void ForgetPasswordReturnBadRequest()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.ForgetPasswordAsync(It.IsAny<ForgetPasswordViewModel>())).ReturnsAsync((string token) => token);
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config) => config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object, service1.Object, DistrubutedCache.Object);
            //arrange
            var model = new ForgetPasswordViewModel();

            //act
            var result = await controller.ForgetPassword(model);
            var response = result as BadRequestObjectResult;
            Token = response.Value;
            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void ResetPasswordReturnOk()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.ResetPasswordAsync(It.IsAny<ResetPasswordViewModel>())).ReturnsAsync((IdentityResult result) => result); ;
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config) => config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object, service1.Object, DistrubutedCache.Object);
            //arrange
            var model = new ResetPasswordViewModel 
            {
                Email="rajeshamadan@gmail.com",
                Token=(string)Token,
                Password="9686454Wm",
                ConfirmPassword="9686454Ww"
            };

            //act
            var result = await controller.ResetPassword(model);
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void ResetPasswordReturnBadRequest()
        {
            var service = new Mock<IAccount>();
            service.Setup(p => p.ResetPasswordAsync(It.IsAny<ResetPasswordViewModel>())).ReturnsAsync((IdentityResult result) => result); ;
            var service1 = new Mock<IConfiguration>();
            service1.Setup(p => p.GetSection(It.IsAny<string>())).Returns((IConfigurationSection config) => config);
            var DistrubutedCache = new Mock<IDistributedCache>();
            var controller = new AccountController(service.Object, service1.Object, DistrubutedCache.Object);
            //arrange
            var model = new ResetPasswordViewModel();
            //act
            var result = await controller.ResetPassword(model);
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }
      
    }
}
