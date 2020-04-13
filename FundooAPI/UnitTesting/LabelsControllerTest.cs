using System;
using System.Threading.Tasks;
using ApplicationBusiness.Interfaces;
using Common.Models;
using FundooAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTesting
{
    /// <summary>
    /// Test Class for LabelsController
    /// </summary>
    public class LabelsControllerTest
    {
        /// <summary>
        /// this method tests the AddLabel Action
        /// </summary>
        /// <returns>Result</returns>
        [Fact]
        public async Task AddLabel_Returns_NotFoundObjectResult()
        {
            var service = new Mock<ILabelManager>();
            var controller = new LabelsController(service.Object);
            var model = new LabelsModel()
            {
                Label="Hello",
                LBNumber=3
            };

            var result =await controller.Add(model);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        /// <summary>
        /// this method tests the GetLabel Action
        /// </summary>
        [Fact]
        public void GetLabel_Returns_OkObjectResult()
        {
            //// Arrange
            var service = new Mock<ILabelManager>();
            var controller = new LabelsController(service.Object);

            var num = 1;

            //// act
            var result = controller.Get(num);

            //// Assert
            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// this method tests the GetAll Action
        /// </summary>
        [Fact]
        public void GetAll_Returns_OkObjectResult()
        {
            //// Arrange
            var service = new Mock<ILabelManager>();
            var controller = new LabelsController(service.Object);

            //// Act
            var result = controller.GetAll();

            //// Assert
            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// this method tests the Delete Action
        /// </summary>
        [Fact]
        public async void Delete_Returns_NotFoundResult()
        {
            //// Arrange
            var service = new Mock<ILabelManager>();
            var controller = new LabelsController(service.Object);

            //// Act
            var result = await controller.Delete(1);

            //// Assert
            Assert.IsType<NotFoundResult>(result);
        }

        /// <summary>
        /// this method tests the Update Action
        /// </summary>
        [Fact]
        public async void Update_Returns_OkObjectResult()
        {
            //// Arrange
            var service = new Mock<ILabelManager>();
            var controller = new LabelsController(service.Object);
            var model = new LabelsModel()
            {
                LBNumber=1,
                Label="Dude"
            };

            //// act
            var result =await  controller.Update(model);

            //// Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
