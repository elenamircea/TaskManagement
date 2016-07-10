using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Text { get; set; }
        [Display(Name = "Posted at")]
        public DateTime PostedAt { get; set; }
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int TaskId { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}
