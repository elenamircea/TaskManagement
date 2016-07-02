using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DomainClasses;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer
{
    public class EntityFrameworkContext : IdentityDbContext<AppUser>
    {
        public DbSet<Task> TaskList { get; set; }

        public DbSet<Comment> CommentList { get; set; }
        public DbSet<Team> TeamList { get; set; }
    }
}
