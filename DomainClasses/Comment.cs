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
        public DateTime PostedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public String Name { get; set; }
        public int TaskId { get; set; }

    }
}
