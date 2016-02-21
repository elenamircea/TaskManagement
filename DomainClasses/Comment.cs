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
        public String Text { get; set; }
        [Display(Name = "Posted at")]
        public DateTime PostedAt { get; set; }
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }
        public String Name { get; set; }
        public int TaskId { get; set; }

    }
}
