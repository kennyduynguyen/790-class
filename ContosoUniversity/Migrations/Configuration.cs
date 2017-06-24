namespace ContosoUniversity.Migrations
{
    using ContosoUniversity.Controllers;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PwdHasher;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.Controllers.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ContosoUniversity.Models.ApplicationDbContext";
        }

        protected override void Seed(ContosoUniversity.Controllers.ApplicationDbContext context)
        {
            var password = new PasswordHasher();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Roles.AddOrUpdate(
                p => p.Id,
                new IdentityRole { Id = "1", Name = "Admin"},
                new IdentityRole { Id = "2", Name = "Student" },
                new IdentityRole { Id = "3", Name = "Teacher" }

            );
         
        }
    }
}
