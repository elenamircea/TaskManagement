using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string TeamLeaderUserId { get; set; }
        public List<AppUser> TeamMembers { get; set; }
        [NotMapped]
        [Display(Name = "TeamLeader Email")]
        public string TeamLeaderEmail { get; set; }
    }
}
