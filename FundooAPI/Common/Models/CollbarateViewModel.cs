using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class CollbarateViewModel
    {
        [Key]
        public int Id { get; set; }
        public int NoteId { get; set; }
        public string SenderEmail { get; set; }
        public string ReciveEmail { get; set; }
    }
}
