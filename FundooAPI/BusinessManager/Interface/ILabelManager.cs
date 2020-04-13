using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace ApplicationBusiness.Interfaces
{
    /// <summary>
    /// To Manage the Labels
    /// </summary>
    public interface ILabelManager
    {
        Task<int> AddLabel(LabelsModel model);
        Task<int> DeleteLabel(int id);
        Task<int> UpdateLabel(LabelsModel model);
        IEnumerable<LabelsModel> GetAllLabels();
        LabelsModel GetLabel(int id);
    }
}
