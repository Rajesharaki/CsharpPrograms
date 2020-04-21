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
    /// ILabelRepositaryImplementation class implement ILabelRepopsitary
    /// </summary>
    public class ILabelRepositaryImplementation : ILabelRepositary
    {
        private readonly AppDBContext _context;
        private readonly IDistributedCache _distrubutedCache;

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="repositary">Inject AppDBContext </param>
        public ILabelRepositaryImplementation(AppDBContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distrubutedCache = distributedCache;
        }

        /// <summary>
        /// AddLabelAsync Method
        /// </summary>
        /// <param name="model">LabelViewModel Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> AddLabelAsync(LabelViewModel model)
        {
            await _context.Labels.AddAsync(model);
            if (await _context.SaveChangesAsync() > 0)
            {
                await this._distrubutedCache.RemoveAsync("Labels");
                return true;
            }
            return false;
        }

        /// <summary>
        /// DeleteAllLabelAsync Method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteAllLabelsAsync(string email)
        {
            var models = _context.Labels.
                 Where(m => m.Email == email && m.IsArchive == false && m.IsTrash == false);
            if (models != null)
            {
                foreach (var model in models)
                {
                    _context.Remove(model);
                }
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this._distrubutedCache.RemoveAsync("Labels");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// DeleteLabelByIdAsync Method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <param name="id">Id Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeletelabelById(string email, int id)
        {
            var model = _context.Labels.
                FirstOrDefault(m => m.Email == email && m.Id == id && m.IsArchive == false && m.IsTrash == false);
            _context.Remove(model);
            if (await _context.SaveChangesAsync() > 0)
            {
                await this._distrubutedCache.RemoveAsync("Labels");
                return true;
            }
            return false;
        }

        /// <summary>
        /// GetAllLabels Method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <returns>IENumerable LabelViewModel</returns>
        public async Task<IEnumerable<LabelViewModel>>GetAllLabels(string email)
        {
            string Key = "Labels";
            var CacheData = this._distrubutedCache.GetString(Key);
            if (CacheData == null)
            {
                List<LabelViewModel> models = _context.Labels.
                    Where(m => m.Email == email && m.IsArchive == false && m.IsTrash == false && m.Pin == true).ToList();
                var unpinmodel = _context.Labels.
                    Where(m => m.Email == email && m.IsArchive == false && m.IsTrash == false && m.Pin == false).ToList();
                foreach (var model in unpinmodel)
                {
                    models.Add(model);
                }
                var JsonData = JsonConvert.SerializeObject(models);
                await this._distrubutedCache.SetStringAsync(Key, JsonData);
                return models;
            }
            else
            {
                var model = JsonConvert.DeserializeObject<List<LabelViewModel>>(CacheData);
                return model;
            }
        }

        /// <summary>
        /// UpdateLabelAsync method
        /// </summary>
        /// <param name="model">LabelViewModel Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateLabelAsync(LabelViewModel model)
        {
            var Updatemodel = _context.Labels.FirstOrDefault(m => m.Id == model.Id && m.Email == model.Email);
            if (Updatemodel.LabelNumber != null)
                Updatemodel.LabelNumber = model.LabelNumber;
            if (Updatemodel.Lable != null)
                Updatemodel.Lable = model.Lable;
            Updatemodel.IsArchive = model.IsArchive;
            Updatemodel.IsTrash = model.IsTrash;
            Updatemodel.ModifiedDateTime = model.ModifiedDateTime;
            Updatemodel.Pin = model.Pin;
            Updatemodel.Reminder = model.Reminder;
            _context.Labels.Update(Updatemodel);
            if (await _context.SaveChangesAsync() > 0)
            {
                await this._distrubutedCache.RemoveAsync("Labels");
                return true;
            }
            return false;
        }

        /// <summary>
        /// IsArchive Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsArchive(int id, string email)
        {
            var model = _context.Labels.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false)
                    model.IsArchive = true;
                else
                    model.IsArchive = false;
                model.ModifiedDateTime = DateTime.Now;
                _context.Labels.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this._distrubutedCache.RemoveAsync("Labels");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// IsTrash Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsTrash(int id, string email)
        {
            var model = _context.Labels.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false)
                    model.IsTrash = true;
                else
                    model.IsTrash = false;
                model.ModifiedDateTime = DateTime.Now;
                _context.Labels.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this._distrubutedCache.RemoveAsync("Labels");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Pin Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Pin(int id, string email)
        {
            var model = _context.Labels.FirstOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false && model.Pin == false)
                    model.Pin = true;
                else
                    model.Pin = false;
                model.ModifiedDateTime = DateTime.Now;
                _context.Labels.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this._distrubutedCache.RemoveAsync("Labels");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Reminder Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Reminder(int id, string email)
        {
            var model = _context.Labels.SingleOrDefault(m => m.Id == id && m.Email == email);
            if (model != null)
            {
                if (model.IsTrash == false && model.IsArchive == false && model.Reminder == false)
                    model.Reminder = true;
                else
                    model.Reminder = false;
                model.ModifiedDateTime = DateTime.Now;
                _context.Labels.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    await this._distrubutedCache.RemoveAsync("Labels");
                    return true;
                }
            }
            return false;
        }
    }
}
