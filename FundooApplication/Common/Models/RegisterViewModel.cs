using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enter vaild Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password not matched")]
        public string ConfirmPassword { get; set; }
    }
}
