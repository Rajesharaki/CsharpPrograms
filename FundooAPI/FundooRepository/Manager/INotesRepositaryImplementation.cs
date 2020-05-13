using Common.Models;
using FundooRepository.DBContext;
using FundooRepository.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FundooRepository.Manager
{
    /// <summary>
    /// INotesImplementation class implement IRepositary
    /// </summary>
    public class INotesRepositaryImplementation : INoteRepositary
    {
        private AppDBContext _context;
        private readonly IDistributedCache distributedCache;

        /// <summary>
        /// INotesImplementation Constructor injection
        /// </summary>
        /// <param name="repositary">Inject AppDbContext</param>
        public INotesRepositaryImplementation(AppDBContext context, IDistributedCache distributedCache)
        {
            _context = context;
            this.distributedCache = distributedCache;
        }

        /// <summary>
        /// AddNotesAsync Method
        /// </summary>
        /// <param name="file">IFormFile Mandatory</param>
        /// <param name="model">NotesViewMondatory</param>
        /// <returns>int</returns>
        public async Task<int> AddNotesAync(NotesViewModel model)
        {
            var models = await _context.Notes.AddAsync(model);
            this.distributedCache.Remove("Notes");
            return await _context.SaveChangesAsync();

        }

        /// <summary>
        /// DeleteAllNotes method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteAllNotes(string email)
        {
            var models = _context.Notes.Where(m => m.Email == email && m.IsArchive == false && m.IsTrash == false);
            if (models != null)
            {
                foreach (var model in models)
                {
                    _context.Notes.Remove(model);
                }
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            await this.distributedCache.RemoveAsync("Notes");
            return false;
        }

        /// <summary>
        /// DeleteNotesById Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteByIdAsync(int id, string email)
        {
            var model = await _context.Notes.FindAsync(id);
            if (model != null)
            {
                if (model.Email == email && model.IsTrash == false && model.IsArchive == false)
                {
                    _context.Notes.Remove(model);
                    if (await _context.SaveChangesAsync() != 0)
                    {
                        return true;
                    }
                }
            }
            await this.distributedCache.RemoveAsync("Notes");
            return false;
        }

        /// <summary>
        /// GetAllNotes Method
        /// </summary>
        /// <param name="email">Email mandatory</param>
        /// <returns>IEnumerable NotesViewModel</returns>
        public IEnumerable<NotesViewModel> GetAllNotes(string email)
        {
            var key = "Notes";
            var CacheData = this.distributedCache.GetString(key);
            if (CacheData == null)
            {
                ////first it fetch Pin notes from the database
                List<NotesViewModel> model = _context.Notes.
                Where(m => m.Email == email && m.IsArchive == false && m.IsTrash == false && m.Pin == true).ToList();

                ////fetch Unpin notes from the database
                var unpinmodel = _context.Notes.
                Where(m => m.Email == email && m.IsArchive == false && m.IsTrash == false && m.Pin == false).ToList();

                ////add pin and unpin notes 
                foreach (var models in unpinmodel)
                {
                    model.Add(models);
                }

                //// converting the List model to String
                var jsonFile = JsonConvert.SerializeObject(model);
                //// Storing the Strng in the Redis Cache
                this.distributedCache.SetString(key, jsonFile);
                return model;
            }
            else
            {
                var model = JsonConvert.DeserializeObject<List<NotesViewModel>>(CacheData);
                return model;
            }
        }

        /// <summary>
        /// GetNotesByIdAsync Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>NotesViewModel</returns>
        public async Task<NotesViewModel> GetNotesByIdAsync(int id, string email)
        {
            string Key = "Notes";
            var CacheData = this.distributedCache.GetString(Key);
            if (CacheData == null)
            {
                var model = await _context.Notes.FindAsync(id);
                if (model.Email == email && model.IsArchive == false && model.IsTrash == false)
                {
                    var JsonData = JsonConvert.SerializeObject(model);
                    await this.distributedCache.SetStringAsync(Key, JsonData);
                    return model;
                }
                return null;
            }
            else
            {
                var model = JsonConvert.DeserializeObject<NotesViewModel>(CacheData);
                return model;
            }
        }
        /// <summary>
        /// IsArchive Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsArchive(int id, string email)
        {
            var model = _context.Notes.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false)
                    model.IsArchive = true;
                else
                    model.IsArchive = false;
                model.Modifieddate = DateTime.Now;
                _context.Notes.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this.distributedCache.RemoveAsync("Notes");
                    return true;

                }
            }
            return false;
        }

        /// <summary>
        /// IsTrash Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsTrash(int id, string email)
        {
            var model = _context.Notes.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false)
                    model.IsTrash = true;
                else
                    model.IsTrash = false;
                model.Modifieddate = DateTime.Now;
                _context.Notes.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this.distributedCache.RemoveAsync("Notes");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Pin Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Pin(int id, string email)
        {
            var model = _context.Notes.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false && model.Pin == false)
                    model.Pin = true;
                else
                    model.Pin = false;
                model.Modifieddate = DateTime.Now;
                _context.Notes.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this.distributedCache.RemoveAsync("Notes");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Reminder Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Reminder(int id, string email)
        {
            var model = _context.Notes.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false && model.Reminder == false)
                    model.Reminder = true;
                else
                    model.Reminder = false;
                model.Modifieddate = DateTime.Now;
                _context.Notes.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this.distributedCache.RemoveAsync("Notes");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// UpdateNotesAsync Method
        /// </summary>
        /// <param name="model">NotesViewModel Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateNotesAsync(NotesViewModel model)
        {
            var Updatemodel = _context.Notes.FirstOrDefault(m => m.Id == model.Id);
            if (Updatemodel.Image != null)
            {
                Updatemodel.Image = model.Image;
            }
            if (Updatemodel.Title != null)
                Updatemodel.Title = model.Title;
            if (Updatemodel.Description != null)
                Updatemodel.Description = model.Description;
            if (Updatemodel.Modifieddate != null)
                Updatemodel.Modifieddate = model.Modifieddate;
            Updatemodel.IsArchive = model.IsArchive;
            Updatemodel.IsTrash = model.IsTrash;
            Updatemodel.Reminder = model.Reminder;
            Updatemodel.Pin = model.Pin;
            _context.Notes.Update(Updatemodel);
            if (await _context.SaveChangesAsync() > 0)
            {
                await this.distributedCache.RemoveAsync("Notes");
                return true;
            }
            return false;
        }

        public async Task<bool> AddCollbaratorAsync(CollbarateViewModel model)
        {
            var Note = this._context.Notes.FirstOrDefault(m => m.Id == model.NoteId);
            if (Note != null)
            {
                await this._context.Collbarator.AddAsync(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;
            }
            return false;
        }

        public async Task<bool> RemoveCollbaratorAsync(string email, int id)
        {
            var model = _context.Collbarator.FirstOrDefault(m => m.ReciveEmail == email && m.NoteId == id);
            if (model != null)
            {
                _context.Remove(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;
            }
            return false;
        }

        public List<NotesViewModel> GetAllCollbaratorNotes(string email)
        {
            List<NotesViewModel> notesmodelslist = new List<NotesViewModel>();
            var Collbaratormodels = _context.Collbarator.Where(m => m.ReciveEmail == email).ToList();
            if (Collbaratormodels.Count != 0)
            {
                foreach (var model in Collbaratormodels)
                {
                    notesmodelslist.Add(_context.Notes
                     .FirstOrDefault(m => m.Email == model.SenderEmail && m.Id == model.NoteId));
                }
                return notesmodelslist;
            }
            return null;
        }

        public IQueryable GetNotesAndLabel(int id,string email)
        {
            var model = _context.Notes.Where(e=>e.Id==id&&e.Email==email)
                        .Join(_context.Labels,
                         Notes => Notes.LabelId,
                         Labels => Labels.LabelId,
                        (Notes, Labels) => new
                         {
                            Notes_LabelId=Notes.LabelId,
                            Notes_Title = Notes.Title,
                            Notes_Description = Notes.Description,
                            Notes_CreatedDateAndTime = Notes.CreatedDate,
                            Notes_ModeifiedDateAndTime = Notes.Modifieddate,
                            Label_Id=Labels.LabelId,
                            LabelNumber = Labels.LabelNumber,
                            Label_Name = Labels.Lable,
                            Label_CreatedDateAndTime = Labels.CreatedDateTime,
                            Label_ModifiedDateAndTime = Labels.ModifiedDateTime
                         });
            return model;
        }

        public IEnumerable<NotesViewModel> Search(string title)
        {
            return _context.Notes.Where(e=>e.Title.StartsWith(title));
        }
    }
}
