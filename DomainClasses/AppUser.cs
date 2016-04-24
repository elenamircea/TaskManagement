using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class AppUser : IdentityUser
    {
        public List<Task> tasks { get; set; }
        public List<Comment> comments { get; set; }
    }
}
