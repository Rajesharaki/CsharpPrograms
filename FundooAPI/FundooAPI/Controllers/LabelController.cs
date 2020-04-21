using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace FundooAPI.Controllers
{
    /// <summary>
    /// LabelController Class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly ILabel _label;

        /// <summary>
        /// LabelController Constructor
        /// </summary>
        /// <param name="label">constructor injection</param>
        public LabelController(ILabel label)
        {
            _label = label;
        }

        /// <summary>
        /// AddLabelAsync Method
        /// </summary>
        /// <param name="model">LabelViewModel Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("AddLabel")]
        public async Task<IActionResult> AddLabelAync([FromForm]LabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Email = User.Identity.Name;
                model.CreatedDateTime = DateTime.Now;
                model.ModifiedDateTime = DateTime.Now;
                var result=await _label.AddLabelAsync(model);
                if (result == true)
                    return Ok(new { Status = "Label Successfully added " });
                return NotFound(new { Status = "Failed" });
            }
            return BadRequest(new { Status = "Enter Valid Information" });
        }

        /// <summary>
        /// GetAllLabels
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("GetAllLabelsAsync")]
        public async Task<IActionResult> GetAllLablesAsync()
        {
            string email=User.Identity.Name;
            var result= await _label.GetAllLabels(email);
            if (result.Count()>0)
                return Ok(new { Labels = result });
            return NotFound(new { Stauts = "Not Found Any label with this Email: " + email });
        }

        /// <summary>
        /// DeleteLabelById
        /// </summary>
        /// <param name="id">Id mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("DeleteLabel")]
        public async Task<IActionResult> DeleteLableByIdAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var result=await _label.DeletelableByIdAsync(email, id);
                if (result == true)
                    return Ok(new { Status = "Id with " + id + " is Successfully deleted" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id Should be greater than 0" });
        }

        /// <summary>
        /// DeleteAllLabelsAsync method
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("DeleteAllLabels")]
        public async Task<IActionResult> DeleteAllLabelsAsync()
        {
            var email = User.Identity.Name;
            var result=await _label.DeleteAllLabelsAsync(email);
            if (result == true)
                return Ok(new { Status = "Successfully Deleted all labels" });
            return NotFound(new { Status = "Not found any labels in this email :" + email });
        }

        /// <summary>
        /// UpdateLabelAsync method
        /// </summary>
        /// <param name="model">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("UpdateLabel")]
        public async Task<IActionResult> UpdateLabelAsync([FromForm] LabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Email = User.Identity.Name;
                model.ModifiedDateTime = DateTime.Now;
                var result=await _label.UpdatelabelAsync(model);
                if (result == true)
                    return Ok(new { Status = "Successfully Updated" });
                return NotFound(new { Status = "Not Found Any Labels with this email: " + model.Email });
            }
            return BadRequest(new { Status = "Enter Valid Information" });
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
                var result = await _label.IsTrash(id, email);
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
                var result = await _label.IsArchive(id, email);
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
                var result = await _label.Pin(id, email);
                if (result == true)
                    return Ok(new { Status = "Successed" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be Greter than 0 please enter valid id" });
        }

        /// <summary>
        /// ReminderAsync method
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Reminder")]
        public async Task<IActionResult> ReminderAsync(int id)
        {
            if (id > 0)
            {
                string email = User.Identity.Name;
                var result = await _label.Reminder(id, email);
                if (result == true)
                    return Ok(new { Status = "Successed" });
                return NotFound(new { Status = "Id with " + id + " is Not Found" });
            }
            return BadRequest(new { Status = "Id is Mandatory and Id should be Greter than 0 please enter valid id" });
        }


    }
}