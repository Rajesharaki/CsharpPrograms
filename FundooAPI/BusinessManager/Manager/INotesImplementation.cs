using BusinessManager.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common.Models;
using FundooRepository.DBContext;
using FundooRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Manager
{
    /// <summary>
    /// INotesImplementation class implement INotes interface
    /// </summary>
    public class INotesImplementation : INotes
    {
        private INoteRepositary _repositary;

        /// <summary>
        /// INotesImplementation Constructor injection
        /// </summary>
        /// <param name="repositary">Inject INoteRepositary</param>
        public INotesImplementation(INoteRepositary repositary)
        {
            _repositary = repositary;
        }

        public Task<bool> AddCollbaratorAsync(CollbarateViewModel model)
        {
           return _repositary.AddCollbaratorAsync(model);
        }

        /// <summary>
        /// AddNotesAsync Method
        /// </summary>
        /// <param name="file">IFormFile Mandatory</param>
        /// <param name="model">NotesViewMondatory</param>
        /// <returns>bool</returns>
        public async Task<bool> AddNotesAsync(IFormFile file, NotesViewModel model)
        {
            model.Image = this.Image(file);
            var result = await _repositary.AddNotesAync(model);
            if (result == 0)
                return false;
            return true;
        }
         
        /// <summary>
        /// DeleteAllNotes method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteAllNotes(string email)
        {
            return await _repositary.DeleteAllNotes(email);
        }

        /// <summary>
        /// DeleteNotesById Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteByIdAsync(int id,string email)
        {
            return await _repositary.DeleteByIdAsync(id,email);
        }

        public List<NotesViewModel> GetAllCollbaratorNotes(string email)
        {
            return _repositary.GetAllCollbaratorNotes(email);
        }

        /// <summary>
        /// GetAllNotes Method
        /// </summary>
        /// <param name="email">Email mandatory</param>
        /// <returns>IEnumerable NotesViewModel</returns>
        public IEnumerable<NotesViewModel> GetAllNotes(string email)
        {
            return _repositary.GetAllNotes( email);
        }

        public IQueryable GetNotesAndLabel(int id,string email)
        {
            return _repositary.GetNotesAndLabel(id,email);
        }

        /// <summary>
        /// GetNotesByIdAsync Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>NotesViewModel</returns>
        public async Task<NotesViewModel> GetNotesByIdAsync(int id,string email)
        {
            var model = await _repositary.GetNotesByIdAsync(id,email);
            return model;
        }

        /// <summary>
        /// Image method
        /// </summary>
        /// <param name="file">IFormFile Mandatory</param>
        /// <returns>string Url</returns>
        public string Image(IFormFile file)
         {
            if (file == null)
                return null;
            var filePath = file.OpenReadStream();
            var fileName = file.FileName;
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("bridgelabzsolution","722287876843485", "4xcem4PorStyWYuTdXVmcKulNqg");
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            var uploadparameters = new ImageUploadParams
            {
                File = new FileDescription(fileName, filePath)
            };
            var result = cloudinary.Upload(uploadparameters);
            return result.Uri.ToString();
        }

        /// <summary>
        /// IsArchive Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsArchive(int id, string email)
        {
            return await _repositary.IsArchive(id,email);
        }

        /// <summary>
        /// IsTrash Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsTrash(int id,string email)
        {
            return await _repositary.IsTrash(id,email);
        }

        /// <summary>
        /// Pin Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Pin(int id, string email)
        {
            return await _repositary.Pin(id, email);
        }

        /// <summary>
        /// Reminder Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Reminder(int id, string email)
        {
            return await _repositary.Reminder(id,email);
        }

        public async Task<bool> RemoveCollbaratorAsync(string email,int id)
        {
            return await _repositary.RemoveCollbaratorAsync(email,id);
        }

        public IEnumerable<NotesViewModel> Search(string title)
        {
            return _repositary.Search(title);
        }

        /// <summary>
        /// UpdateNotesAsync Method
        /// </summary>
        /// <param name="file">IFormFile Mandatory</param>
        /// <param name="model">NotesViewModel Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateNotesAsync(IFormFile file, NotesViewModel model)
        {
            model.Image = this.Image(file);
            return await _repositary.UpdateNotesAsync(model);
        }
    }
}
