using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface ILabel
    {
        Task<bool> AddLabelAsync(LabelViewModel model);
        Task<IEnumerable<LabelViewModel>> GetAllLabels(string email);
        Task<bool> DeletelableByIdAsync(string email, int id);
        Task<bool> DeleteAllLabelsAsync(string email);
        Task<bool> UpdatelabelAsync(LabelViewModel model);
        Task<bool> IsTrash(int id, string email);
        Task<bool> IsArchive(int id, string email);
        Task<bool> Pin(int id, string email);
        Task<bool> Reminder(int id, string email);
    }
}
