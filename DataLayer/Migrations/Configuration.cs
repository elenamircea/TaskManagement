using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//probleme cu entity framework migrations=> tools->nuget package manager->pm console default project:DataLayer
//update-database

namespace DataLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataLayer.EntityFrameworkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
        }
    }
}
