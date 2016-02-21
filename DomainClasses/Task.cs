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
        public String Title {get; set;}
        public String Description { get; set; }
        public int Time { get; set; }
        public String AsignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Comment> comments { get; set; }
    }
}
