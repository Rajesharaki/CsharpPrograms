using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleChatRoom.Models
{
    public class Messages
    {
        public int id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime when {get;set;}
        public string UserID { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
