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
    public class LabelsRepositoryImpl : ILabelsRepositary
    {
        private readonly AppDbContext context;
        public LabelsRepositoryImpl(AppDbContext context)
        {
            this.context = context;
        }
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
        public IEnumerable<LabelsModel> GetAllLabels()
        {
            return this.context.Labels;
        }
        public LabelsModel GetLabel(int id)
        {
            var result = this.context.Labels.FirstOrDefault(o => o.LBNumber == id);
            if(result!=null)
            {
                return result;
            }
            return null;
        }
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
