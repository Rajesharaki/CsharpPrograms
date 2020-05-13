using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FundooAPI.Controllers
{
    /// <summary>
    /// Notes Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private INotes _notes;

        /// <summary>
        /// Notes Controller constructor
        /// </summary>
        /// <param name="notes">inject INotes interface</param>
        public NotesController(INotes notes)
        {
            _notes = notes;
        }

        /// <summary>
        /// AddNotesAsync method
        /// </summary>
        /// <param name="file">IFormFile not Mandatory</param>
        /// <param name="Label_ID">Id Mandatory</param>
        /// <param name="title">Mandatory</param>
        /// <param name="description">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("AddNotes")]
        public async Task<IActionResult> AddNotesAsync(IFormFile file,int Label_ID,string title,string description)
        {

            if (Label_ID>0&&title!=null&&description!=null)
            {
                NotesViewModel model = new NotesViewModel
                {
                    Email = User.Identity.Name,
                    Title = title,
                    Description = description,
                    CreatedDate = DateTime.Now,
                    Modifieddate = DateTime.Now,
                    IsArchive = false,
                    IsTrash=false,
                    Pin=false,
                    Reminder=false,
                    LabelId=Label_ID
                };
                var result = await _notes.AddNotesAsync(file, model);
                if (result == true)
                {
                    return Ok(new { Id = model.Id, Status = "Successfully Notes added" });
                }
                return NotFound(new { Status = "Failed to add notes" });
            }
            return BadRequest(new { Status = "please Enter valid Information" });
        }

        /// <summary>
        /// GetNotesById 
        /// </summary>
        /// <param name="id">Manadatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("GetNotesById")]
        public async Task<IActionResult> GetNotesByIdAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var model = await _notes.GetNotesByIdAsync(id, email);
                if (model == null)
                    return NotFound(new { Status = "id with " + id + " Not found...! Enter valid Email" });
                return Ok(new { Notes = model });
            }
            return BadRequest(new { Status = "Id is Mandatory ! please enter id" });
        }

        /// <summary>
        /// GetAllNotes Methods
        /// </summary>
        /// <returns>all notes</returns>
        [HttpPost]
        [Route("GetAllNotes")]
        public IActionResult GetAllNotes()
        {
            string Email = User.Identity.Name;
            List<NotesViewModel> model = _notes.GetAllNotes(Email).ToList();
            if (model.Count > 0)
                return Ok(new { Notes = model });
            return NotFound(new { Stauts = "Not Found Any Notes with this Email: " + Email });
        }

        /// <summary>
        /// DeleteNotesById
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("DeleteNotesById")]
        public async Task<IActionResult> DeleteNotesByIdAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                if (await _notes.DeleteByIdAsync(id, email))
                {
                    return Ok(new { Status = "Id= " + id + " Notes Successfully deleted" });
                }
                return NotFound(new { Status = "Id With " + id + " Not Found Any Notes.! Enter Valid Id" });
            }
            return BadRequest(new { status = "Id is Mandatory and Id Should be greater than 0" });
        }

        /// <summary>
        /// UpdateNotesAsync Method
        /// </summary>
        /// <param name="model">NotesViewModel Mandatory</param>
        /// <param name="file">IFromFile Manadatory</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateNotes")]
        public async Task<IActionResult> UpdateNotesAsync([FromForm]NotesViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                model.Email = User.Identity.Name;
                model.Modifieddate = DateTime.Now;
                var result = await _notes.UpdateNotesAsync(file, model);
                if (result == true)
                    return Ok(new { Status = "Successfully Updated your notes" });
                return NotFound(new { status = "Id with" + model.Id + " is Not found" });
            }
            return BadRequest(new { Status = "please Enter valid Information..>!" });
        }

        /// <summary>
        /// IsTrash method
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("IsTrash")]
        public async Task<IActionResult> IsTrashAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var result = await _notes.IsTrash(id, email);
                if (result == true)
                    return Ok(new { Status = "Successed" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be Greter than 0 please enter valid id" });
        }

        /// <summary>
        /// IsArchive method
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("IsArchive")]
        public async Task<IActionResult> IsArchiveAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var result = await _notes.IsArchive(id, email);
                if (result == true)
                    return Ok(new { Status = "Successed" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be Greter than 0 please enter valid id" });
        }

        /// <summary>
        /// Pin method
        /// </summary>
        /// <param name="id">Id Mandaatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Pin")]
        public async Task<IActionResult> PinAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var result = await _notes.Pin(id, email);
                if (result == true)
                    return Ok(new { Status = "Successed" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be Greter than 0 please enter valid id" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Reminder")]
        public async Task<IActionResult> ReminderAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var result = await _notes.Reminder(id, email);
                if (result == true)
                    return Ok(new { Status = "Successed" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be Greter than 0 please enter valid id" });
        }

        /// <summary>
        /// DeleteAllNotesAsync
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("DeleteAllNotes")]
        public async Task<IActionResult> DeleteAllNotesAsync()
        {
            string email = User.Identity.Name;
            var result = await _notes.DeleteAllNotes(email);
            if (result == true)
                return Ok(new { Status = "Successfully deleted" });
            return NotFound(new { Status = "Failed" });
        }

        /// <summary>
        /// GetNotesAndLabel
        /// </summary>
        /// <param name="Note_Id">Id Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("GetNotesAndLabel")]
        public IActionResult GetNotesAndLabel(int Note_Id)
        {
            if (Note_Id > 0)
            {
                string email = User.Identity.Name;
                var model=_notes.GetNotesAndLabel(Note_Id,email);
                if (model.Any())
                {
                    return Ok(new { NotesAndLabels = model });
                }
                return NotFound(new { Status="Not found any notes with Id ="+Note_Id});
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be more than Zero" });
        }

        /// <summary>
        /// SearchNotes
        /// </summary>
        /// <param name="Title">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("SearchNotes")]
        public IActionResult SearchNotes(string Title)
        {
            if (Title != null)
            {
                var models=_notes.Search(Title);
                if (models.Count()!=0)
                {
                    return Ok(new { Notes=models});
                }
                return NotFound(new { Status="Not Found any notes with Title= "+Title});
            }
            return BadRequest(new {Status="Title is mandatory"});
        }
    }
}