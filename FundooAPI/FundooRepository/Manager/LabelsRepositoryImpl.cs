using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRepository.Context;
using ApplicationRepository.Interfaces;
using Common.Models;


namespace ApplicationRepository.Services
{
    /// <summary>
    /// this class implements the ILabelsRepository
    /// </summary>
    public class LabelsRepositoryImpl : ILabelsRepository
    {
        /// <summary>
        /// private Field for DbContext object
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor injection of DbContext
        /// </summary>
        /// <param name="context">Injects the DbContext object</param>
        public LabelsRepositoryImpl(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds the New Label
        /// </summary>
        /// <param name="model">From body</param>
        /// <returns>result</returns>
        public async Task<int> AddLabel(LabelsModel model)
        {
            //// checking wether the same labelmodel exists in the table
            var exists = this.context.Labels.FirstOrDefault(o => o.LBNumber == model.LBNumber);
            
            //// if not exists then adding the data to the table
            if(exists==null)
            {
                await this.context.Labels.AddAsync(model);
                return await this.context.SaveChangesAsync();
            }
            return 0;
        }

        /// <summary>
        /// Deltes the label based on Id
        /// </summary>
        /// <param name="id">from body</param>
        /// <returns>Resul</returns>
        public async Task<int> DeleteLabel(int id)
        {
            var result = this.context.Labels.FirstOrDefault(o => o.LBNumber == id);
            if(result!=null)
            {
                this.context.Labels.Remove(result);
                return await this.context.SaveChangesAsync();
            }
            return 0;
        }

        /// <summary>
        /// Gets all the Labels
        /// </summary>
        /// <returns>Labels</returns>
        public IEnumerable<LabelsModel> GetAllLabels()
        {
            return this.context.Labels;
        }

        /// <summary>
        /// Gets particular label based on id
        /// </summary>
        /// <param name="id">from body</param>
        /// <returns>result</returns>
        public LabelsModel GetLabel(int id)
        {
            var result = this.context.Labels.FirstOrDefault(o => o.LBNumber == id);
            if(result!=null)
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// update the Label if it exists
        /// </summary>
        /// <param name="id">from body</param>
        /// <param name="label">new label from body</param>
        /// <returns></returns>
        public async Task<int> UpdateLabel(int id, string label)
        {

            var Label = this.context.Labels.FirstOrDefault(o => o.LBNumber == id);
            if (Label != null && label != null)
            {
                Label.Label = label;
                this.context.Labels.Update(Label);
                return await this.context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
