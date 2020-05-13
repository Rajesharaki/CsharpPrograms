using BusinessManager.Interface;
using BusinessManager.Manager;
using Common.Models;
using FundooAPI.Controllers;
using FundooRepository.Interface;
using FundooRepository.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting
{
    public class NotesControllerTest
    {
        [Fact]
        public async void AddNotesNotesReturnOk()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.AddNotesAsync(It.IsAny<IFormFile>(), It.IsAny<NotesViewModel>())).ReturnsAsync(true);
            var controller = new NotesController(service.Object);

            //arrage
            var model = new NotesViewModel
            {
                Email = "rajeshmadan@gmail.com",
                Title = "Fundoo Api",
                Description = "UnitTesting",
                IsArchive = false,
                IsTrash = false,
                Pin = false,
                Reminder = false,
                Color = "red",
            };
            //act
            var result=await controller.AddNotesAsync(null,2,"title","Description");
            var  response=result as OkObjectResult;

            //assert
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void AddNotesReturnBadRequest()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.AddNotesAsync(It.IsAny<IFormFile>(), It.IsAny<NotesViewModel>())).ReturnsAsync(true);
            var controller = new NotesController(service.Object);

            //act
            var result = await controller.AddNotesAsync(null, 2, "title", "Description");
            var response = result as BadRequestObjectResult;

            //assert
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public void GetAllNotesReturnOK()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.GetAllNotes(It.IsAny<string>())).Returns((IEnumerable<NotesViewModel> model) => model);
            var controller = new NotesController(service.Object);
            //act
            var result =  controller.GetAllNotes();
            var response = result as OkObjectResult;

            //assert
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void GetAllNotesReturnNotFount()
        {

            var service = new Mock<INotes>();
            service.Setup(p => p.GetAllNotes(It.IsAny<string>())).Returns((IEnumerable<NotesViewModel> model) => model);
            var controller = new NotesController(service.Object);
            //act
            var result = controller.GetAllNotes();
            var response = result as NotFoundObjectResult;

            //assert
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void GetAllNotesReturnBadRequest()
        {

            var service = new Mock<INotes>();
            service.Setup(p => p.GetAllNotes(It.IsAny<string>())).Returns((IEnumerable<NotesViewModel> model) => model);
            var controller = new NotesController(service.Object);
            //act
            var result = controller.GetAllNotes();
            var response = result as BadRequestObjectResult;

            //assert
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void GetNotesById_Return_Ok()
        {

            var service = new Mock<INotes>();
            service.Setup(p => p.GetNotesByIdAsync(It.IsAny<int>(),It.IsAny<string>())).ReturnsAsync((NotesViewModel model) => model);
            var controller = new NotesController(service.Object);
            //act
            var result =await controller.GetNotesByIdAsync(1);
            var response = result as OkObjectResult;

            //assert
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void GetNotesById_Return_NotFound()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.GetNotesByIdAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((NotesViewModel model) => model);
            var controller = new NotesController(service.Object);
            //act
            var result = await controller.GetNotesByIdAsync(1);
            var response = result as NotFoundObjectResult;

            //assert
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public async void GetNotesById_Return_BadRequest()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.GetNotesByIdAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((NotesViewModel model) => model);
            var controller = new NotesController(service.Object);
            //act
            var result = await controller.GetNotesByIdAsync(1);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void DeleteNotesById_Return_Ok()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.DeleteByIdAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);
            //act
            var result = await controller.DeleteNotesByIdAsync(1);
            var response = result as OkObjectResult;

            //assert
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void DeleteNotesById_Return_NotFound()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.DeleteByIdAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);
            //act
            var result = await controller.DeleteNotesByIdAsync(1);
            var response = result as NotFoundObjectResult;

            //assert
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public async void DeleteNotesById_Return_BadRequest()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.DeleteByIdAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);
            //act
            var result = await controller.DeleteNotesByIdAsync(1);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void DeleteAllNotes_Return_BadRequest()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.DeleteAllNotes(It.IsAny<string>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);
            //act
            var result = await controller.DeleteAllNotesAsync();
            var response = result as BadRequestObjectResult;

            //assert
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void UpdateNotesById_Return_OK()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.UpdateNotesAsync(It.IsAny<IFormFile>(),It.IsAny<NotesViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);

            //arrange
            var model = new NotesViewModel
            {
                Id=1,
                Email = "rajeshmadan@gmail.com",
                Title = "Fundoo Api",
                Description = "UnitTesting",
                IsArchive = false,
                IsTrash = false,
                Pin = false,
                Reminder = false,
                Color = "red",
            };
            //act
            var result = await controller.UpdateNotesAsync(model,null);
            var response = result as OkObjectResult;

            //assert
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void UpdateNotesById_Return_NotFound()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.UpdateNotesAsync(It.IsAny<IFormFile>(), It.IsAny<NotesViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);

            //arrange
            var model = new NotesViewModel
            {
                Id=99,
                Email = "rajeshmadan@gmail.com",
                Title = "Fundoo Api",
                Description = "UnitTesting",
                IsArchive = false,
                IsTrash = false,
                Pin = false,
                Reminder = false,
                Color = "red",
            };
            //act
            var result = await controller.UpdateNotesAsync(model, null);
            var response = result as NotFoundObjectResult;

            //assert
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public async void UpdateNotesById_Return_BadRequest()
        {
            var service = new Mock<INotes>();
            service.Setup(p => p.UpdateNotesAsync(It.IsAny<IFormFile>(), It.IsAny<NotesViewModel>())).ReturnsAsync((bool value) => value);
            var controller = new NotesController(service.Object);

            //arrange
            var model = new NotesViewModel();
            //act
            var result = await controller.UpdateNotesAsync(model, null);
            var response = result as BadRequestObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);
        }
    }
}
