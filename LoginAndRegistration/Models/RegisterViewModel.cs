using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Passwords donot match")]
        public string ConfirmPassword { get; set; }
    }
}
