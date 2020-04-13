using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    /// <summary>
    /// ChangePasswordViewModel class
    /// </summary>
    public class ChangePasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Password Not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
