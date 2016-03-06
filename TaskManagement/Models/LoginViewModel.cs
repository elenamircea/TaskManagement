using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Error message.")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage="Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}