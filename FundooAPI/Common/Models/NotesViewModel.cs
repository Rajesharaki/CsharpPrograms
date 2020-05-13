using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class NotesViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public bool Reminder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool Pin { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public int LabelId { get; set; }
    }
}
