using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace ApplicationRepository.Interfaces
{
    /// <summary>
    /// this interface provides the methods for managing the Labels
    /// </summary>
    public interface ILabelsRepository
    {
        Task<int> AddLabel(LabelsModel model);
        LabelsModel GetLabel(int id);
        IEnumerable<LabelsModel> GetAllLabels();
        Task<int> UpdateLabel(int id, string Label);
        Task<int> DeleteLabel(int Id);
    }
}
