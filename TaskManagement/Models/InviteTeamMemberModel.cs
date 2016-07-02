using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class InviteTeamMemberModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address.")]
        public string email { get; set; }
    }
}