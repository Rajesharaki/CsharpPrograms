using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class User
    {
        [Key, Display(Name="Identity:")]
        public int ID { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Invalid Entry"), MaxLength(30),Display(Name ="Name: ")]
        public string Name { get; set; }
        [Required, EmailAddress,Display(Name ="Email Address: ")]
        public string  Email { get; set; }
    }
}
