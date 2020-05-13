using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class LabelViewModel
    {
        [Key]
        public int Id { get; set; }
        public int LabelId { get; set; }
        public string Email { get; set; }
        public string LabelNumber { get; set; }
        public string Lable { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set;}
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public bool Reminder { get; set;}
        public bool Pin { get; set; }
    }
}
