using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Title {get; set;}
        public String Description { get; set; }
        public int Time { get; set; }
        [Display(Name = "Asigned to")]
        public String AsignedTo { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }

        public List<Comment> comments { get; set; }
    }
}
