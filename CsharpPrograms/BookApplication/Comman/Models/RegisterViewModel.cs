using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comman.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DataType("email")]
        public string Email { get; set; }

        [Required]
        [DataType("Password")]
        public string Password { get; set; }

        [Required]
        [DataType("Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
