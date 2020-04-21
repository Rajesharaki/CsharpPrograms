using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
    public interface INoteRepositary
    {
        Task<int> AddNotesAync(NotesViewModel model);
        Task<NotesViewModel> GetNotesByIdAsync(int id,string email);
        IEnumerable<NotesViewModel> GetAllNotes(string email);
        Task<bool> DeleteByIdAsync(int id,string email);
        Task<bool> UpdateNotesAsync(NotesViewModel model);
        Task<bool> IsTrash(int id,string email);
        Task<bool> IsArchive(int id, string email);
        Task<bool> Pin(int id, string email);
        Task<bool> Reminder(int id, string email);
        Task<bool> DeleteAllNotes(string email);
    }
}
