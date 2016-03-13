using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class PasswordChangeModel
    {
        [Display(Name = "Current Password")]
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string CurrentPassword { get; set; }
        [Display(Name = "New Password")]
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string ConfirmPassword { get; set; }
    }
}