using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface INotes
    {
        Task<bool> AddNotesAsync(IFormFile file, NotesViewModel model);
        Task<NotesViewModel> GetNotesByIdAsync(int id,string email);
        IEnumerable<NotesViewModel> GetAllNotes(string email);
        Task<bool> DeleteByIdAsync(int id,string email);
        Task<bool> UpdateNotesAsync(IFormFile file, NotesViewModel model);
        Task<bool>IsTrash(int id,string email);
        Task<bool>IsArchive(int id, string email);
        Task<bool> Pin(int id, string email);
        Task<bool> Reminder(int id, string email);
        Task<bool> DeleteAllNotes(string email);
        Task<bool> AddCollbaratorAsync(CollbarateViewModel model);
        Task<bool> RemoveCollbaratorAsync(string email,int id);
        List<NotesViewModel> GetAllCollbaratorNotes(string email);
    }
}
