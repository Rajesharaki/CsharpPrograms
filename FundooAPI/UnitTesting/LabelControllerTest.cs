using BusinessManager.Interface;
using Common.Models;
using FundooAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting
{
    public class LabelControllerTest
    {
        [Fact]
        public async void AddLabelAsync_Return_Ok()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.AddLabelAsync(It.IsAny<LabelViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //arrange
            var model = new LabelViewModel
            {
                Email = "rajeshamadan@gmail.com",
                LabelNumber = "22r",
                Lable = "Fundooapi",
                IsArchive = false,
                IsTrash = false,
                Pin = false,
                Reminder=false
            };

            //act
            var result=await controller.AddLabelAync(model);
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void AddLabelAsync_Return_BadRequest()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.AddLabelAsync(It.IsAny<LabelViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //arrange
            var model = new LabelViewModel();

            //act
            var result = await controller.AddLabelAync(model);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void GetAllLabelAsync_Return_Ok()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.GetAllLabels(It.IsAny<string>())).ReturnsAsync((IEnumerable<LabelViewModel> value) => value);
            var controller = new LabelController(service.Object);

            //act
            var result = await controller.GetAllLablesAsync();
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void DeleteLabelAsync_Return_Ok()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.DeletelableByIdAsync(It.IsAny<string>(),It.IsAny<int>())).ReturnsAsync((bool value)=>value);
            var controller = new LabelController(service.Object);

            //act
            var result = await controller.DeleteLableByIdAsync(1);
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void DeleteLabelAsync_Return_NotFound()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.DeletelableByIdAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //act
            var result = await controller.DeleteLableByIdAsync(100);
            var response = result as NotFoundObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
        }

        static int id;
        [Fact]
        public async void DeleteLabelAsync_Return_BadRequest()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.DeletelableByIdAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //act
            var result = await controller.DeleteLableByIdAsync(id);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void UpdateLabelsAsymc_Return_Ok()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.UpdatelabelAsync(It.IsAny<LabelViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //arrange
            var model = new LabelViewModel
            {
                Id=1,
                Email = "rajeshamadan@gmail.com",
                LabelNumber = "22r",
                Lable = "Fundooapi",
                IsArchive = false,
                IsTrash = false,
                Pin = false,
                Reminder = false
            };

            //act
            var result = await controller.UpdateLabelAsync(model);
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void UpdateLabelsAsymc_Return_NotFound()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.UpdatelabelAsync(It.IsAny<LabelViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //arrange
            var model = new LabelViewModel
            {
                Id = 1000,
                Email = "rajeshamadan@gmail.com",
                LabelNumber = "22r",
                Lable = "Fundooapi",
                IsArchive = false,
                IsTrash = false,
                Pin = false,
                Reminder = false
            };

            //act
            var result = await controller.UpdateLabelAsync(model);
            var response = result as NotFoundObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public async void UpdateLabelsAsymc_Return_BadRequest()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.UpdatelabelAsync(It.IsAny<LabelViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //arrange
            var model = new LabelViewModel();

            //act
            var result = await controller.UpdateLabelAsync(model);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void DeleteAllLabelAsync_Return_Ok()
        {
            var service = new Mock<ILabel>();
            service.Setup(p => p.DeleteAllLabelsAsync(It.IsAny<string>())).ReturnsAsync((bool value) => value);
            var controller = new LabelController(service.Object);

            //act
            var result = await controller.DeleteAllLabelsAsync();
            var response = result as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }
    }
}
