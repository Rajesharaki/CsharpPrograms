using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessManager.Interface;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FundooAPI.Controllers
{
    /// <summary>
    /// Collbarator Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollbaratorController : ControllerBase
    {
        private readonly INotes _notes;

        /// <summary>
        /// CollbaratorController Constructor
        /// </summary>
        /// <param name="notes">Mandatory</param>
        public CollbaratorController(INotes notes)
        {
            _notes = notes;
        }
        /// <summary>
        /// AddCollbaratorAsync method
        /// </summary>
        /// <param name="Email">Email Mandatory</param>
        /// <param name="NoteId">NoteId Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("AddCollbaratorAsync")]
        public async Task<IActionResult> AddCollbaratorAsync([FromForm]string Email, [FromForm] int NoteId)
        {
            if (Email != null && NoteId > 0)
            {
                CollbarateViewModel model = new CollbarateViewModel
                {
                    NoteId = NoteId,
                    SenderEmail = User.Identity.Name,
                    ReciveEmail = Email
                };
                var result = await _notes.AddCollbaratorAsync(model);
                if (result == true)
                    return Ok(new { Status = "Successfully Added" });
                return NotFound(new { Status = "Not found Any Notes with Id " + NoteId });
            }
            return BadRequest(new { Status = "Enter Valid Email and ID" });
        }

        /// <summary>
        /// PushNotification method
        /// </summary>
        /// <param name="DeviceToken"></param>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PushNofication")]
        public dynamic PushNotification(string DeviceToken, string msg, string title)
        {
            string serverKey = "AAAAzAVjb4c:APA91bEl-9-9f1TbXe0FCRW7IEokbP3MwVwutMTPU40vWN8g9obU9qF3QycNsFq_tltrihPikqjg05Yh8Oo4Ik7znZ7JNwG76awCl_Ahokj3mEEBvLiVxeYVR8SYvnNwZeNXYCRoKGIz";
            string senderId = "364117384819";
           // var result = "-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            httpWebRequest.Method = "POST";
            var payload = new
            {
                to = DeviceToken,
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = msg,
                    title = title
                },
            };
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(payload);
                streamWriter.Write(json);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
        /// <summary>
        /// RemoveCollbaratorAsync Method
        /// </summary>
        /// <param name="Email">Email Mandatory</param>
        ///  /// <param name="id">Id Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("RemoveCollbaratorAsync")]
        public async Task<IActionResult> RemoveCollbaratorAsync([FromForm]string Email, int id)
        {
            if (Email != null)
            {
                var result = await _notes.RemoveCollbaratorAsync(Email, id);
                if (result == true)
                    return Ok(new { Status = "Successfully Deleted " });
                return NotFound(new { Status = "Not Found any Notes with Email: " + Email });
            }
            return BadRequest(new { Status = "Email is Mandatory" });
        }

        /// <summary>
        /// GetAllCollabaratorNotes
        /// </summary>
        /// <param name="Email">Email Mandatory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("GetAllCollbaratorNotes")]
        [AllowAnonymous]
        public IActionResult GetAllCollabaratorNotes(string Email)
        {
            if (Email != null)
            {
                var models = _notes.GetAllCollbaratorNotes(Email);
                if (models != null)
                    return Ok(new { Notes = models });
                return NotFound(new { Status = "NotFound any Notes with Email " + Email });
            }
            return BadRequest(new { Status = "Email is Mandatory" });
        }
    }
}