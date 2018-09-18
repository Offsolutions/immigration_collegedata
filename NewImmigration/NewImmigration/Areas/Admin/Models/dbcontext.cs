using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewImmigration.Areas.Admin.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext() : base("dbcontext")
        {
          //  Database.SetInitializer<dbcontext>(new CreateDatabaseIfNotExists<dbcontext>());
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbcontext, NewImmigration.Migrations.Configuration>("dbcontext"));
        }

        public System.Data.Entity.DbSet<NewImmigration.Areas.Admin.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<NewImmigration.Areas.Admin.Models.College> Colleges { get; set; }

        public System.Data.Entity.DbSet<NewImmigration.Areas.Admin.Models.Campus> Campus { get; set; }

        public System.Data.Entity.DbSet<NewImmigration.Areas.Admin.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<NewImmigration.Areas.Admin.Models.Courses> Courses { get; set; }
    }
}