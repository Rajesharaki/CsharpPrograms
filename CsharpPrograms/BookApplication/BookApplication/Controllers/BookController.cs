using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookApplication.ViewModel;
using BookManager.Context;
using BookManager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BookController : ControllerBase
    {
        private readonly IBook _book;
        private readonly IHostingEnvironment _env;

        public BookController(IBook book, IHostingEnvironment env)
        {
            _book = book;
            _env = env;
        }

        [HttpPost]
        [Route("AddBooks")]
        public async Task<IActionResult> AddBooks([FromForm]BookViewModel model)
        {
            string Message = null;

            try
            {
                if (ModelState.IsValid && model != null)
                {
                    var extension=Path.GetExtension(model.CoverPhoto.FileName);

                    if (extension.ToLower()==".jpg"|| extension.ToLower() == ".png"
                        || extension.ToLower() == ".gif"|| extension.ToLower() == ".bng")
                    {
                        if (!Directory.Exists(_env.WebRootPath + "//BooksCoverPhotos//"))
                        {
                            Directory.CreateDirectory(_env.WebRootPath + "//BooksCoverPhotos//");

                        }
                        var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BooksCoverPhotos");
                        string fileName = Guid.NewGuid().ToString() + "-" + model.CoverPhoto.FileName;

                        var path = Path.Combine(directory, fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await model.CoverPhoto.CopyToAsync(stream);
                        }

                        Book book = new Book
                        {
                            Author = model.Author,
                            BookName = model.BookName,
                            ContentType = model.ContentType,
                            Email = User.Identity.Name,
                            Price = model.Price,
                            Stock = model.Stock,
                            CoverPhoto = fileName
                        };

                        var result = await _book.AddBooksAsync(book);

                        if (result > 0)
                            return Ok("Successfully added............");
                    } 
                }
            }
            catch (Exception ex)
            {
                Message =ex.Message.ToString();
            }

            return BadRequest(Message);
        }

        [HttpPost]
        [Route("GetAllBooks")]
        public IActionResult GetAllBook()
        {
            try
            {
                var bookList = _book.GetAllBook();

                if (bookList.Count != 0)
                {
                    return Ok(bookList);
                }
                else
                {
                    return NotFound("Not found any books");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
