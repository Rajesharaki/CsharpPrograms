using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationBusiness.Interfaces;
using ApplicationRepository.Interfaces;
using Common.Models;

namespace ApplicationBusiness.Services
{
    /// <summary>
    /// implementation class of ILabelManager to Manage the Labels
    /// </summary>
    public class LabelManagerImpl : ILabelManager
    {
        private readonly ILabelsRepository repository;

        /// <summary>
        /// Injects the ILabelsRepository implemented object
        /// </summary>
        /// <param name="repository">injects Repository object</param>
        public LabelManagerImpl(ILabelsRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// To Add the Labels
        /// </summary>
        /// <param name="model">Supplied from the body</param>
        /// <returns>Returns the success or failure code</returns>
        public async Task<int> AddLabel(LabelsModel model)
        {
            return await this.repository.AddLabel(model);
        }

        /// <summary>
        /// To delete the Label
        /// </summary>
        /// <param name="id">from body</param>
        /// <returns>result</returns>
        public async Task<int> DeleteLabel(int id)
        {
            return await this.repository.DeleteLabel(id);
        }

        /// <summary>
        /// gets the all the Labels
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabelsModel> GetAllLabels()
        {
            return this.repository.GetAllLabels();
        }

        /// <summary>
        /// Gets the particular label
        /// </summary>
        /// <param name="id">From body</param>
        /// <returns>Result</returns>
        public LabelsModel GetLabel(int id)
        {
            return  this.repository.GetLabel(id);
        }

        /// <summary>
        /// updates the particular Label
        /// </summary>
        /// <param name="model">from body</param>
        /// <returns>result</returns>
        public async Task<int> UpdateLabel(LabelsModel model)
        {
            return await this.repository.UpdateLabel(model.Id, model.Label);
        }
    }
}
