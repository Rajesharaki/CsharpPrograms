using BusinessManager.Interface;
using Common.Models;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Manager
{
    /// <summary>
    /// ILabelImplementation Class ImplementILabel interface
    /// </summary>
    public class ILabelImplementation:ILabel
    {
        private readonly ILabelRepositary _repositary;

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="repositary">Inject ILabelRepositary </param>
        public ILabelImplementation(ILabelRepositary repositary)
        {
            _repositary = repositary;
        }

        /// <summary>
        /// AddLabelAsync Method
        /// </summary>
        /// <param name="model">LabelViewModel Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> AddLabelAsync(LabelViewModel model)
        {
            return await _repositary.AddLabelAsync(model);
        }

        /// <summary>
        /// DeleteAllLabelAsync Method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteAllLabelsAsync(string email)
        {
            return await _repositary.DeleteAllLabelsAsync(email);
        }

        /// <summary>
        /// DeleteLabelByIdAsync Method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <param name="id">Id Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> DeletelableByIdAsync(string email, int id)
        {
            return await _repositary.DeletelabelById(email, id);
        }

        /// <summary>
        /// GetAllLabels Method
        /// </summary>
        /// <param name="email">Email Mandatory</param>
        /// <returns>IENumerable LabelViewModel</returns>
        public async Task<IEnumerable<LabelViewModel>> GetAllLabels(string email)
        {
            return await _repositary.GetAllLabels(email);
        }

        /// <summary>
        /// UpdateLabelAsync method
        /// </summary>
        /// <param name="model">LabelViewModel Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> UpdatelabelAsync(LabelViewModel model)
        {
            return await _repositary.UpdateLabelAsync(model);
        }

        /// <summary>
        /// IsArchive Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsArchive(int id, string email)
        {
            return await _repositary.IsArchive(id, email);
        }

        /// <summary>
        /// IsTrash Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> IsTrash(int id, string email)
        {
            return await _repositary.IsTrash(id, email);
        }

        /// <summary>
        /// Pin Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Pin(int id, string email)
        {
            return await _repositary.Pin(id, email);
        }

        /// <summary>
        /// Reminder Method
        /// </summary>
        /// <param name="id">Id Mandatory</param>
        /// <param name="email">Email Mandatory</param>
        /// <returns>bool</returns>
        public async Task<bool> Reminder(int id, string email)
        {
            return await _repositary.Reminder(id, email);
        }

    }
}
