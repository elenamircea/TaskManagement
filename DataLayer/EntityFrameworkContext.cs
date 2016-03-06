using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DomainClasses;

namespace DataLayer
{
    public class EntityFrameworkContext : DbContext
    {
        public DbSet<Task> TaskList { get; set; }

        public DbSet<Comment> CommentList { get; set; }
    }
}
