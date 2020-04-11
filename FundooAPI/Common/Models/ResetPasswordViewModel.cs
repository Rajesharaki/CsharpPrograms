
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class ResetPasswordViewModel
    {
        public  string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Not Matched")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
