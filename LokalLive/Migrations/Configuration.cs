namespace LokalLive.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LokalLive.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<LokalLive.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LokalLive.Models.ApplicationDbContext context)
        {
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

            AddUserAndRole(context);

            context.Match.AddOrUpdate(p => p.MatchStart,
                new Match
                {
                    MatchName = "Test - test",
                    MatchStart = DateTime.Now,
                    IntermissionStart = DateTime.Now.AddMinutes(45),
                    IntermissionEnd = DateTime.Now.AddMinutes(60),
                    MatchEnd = DateTime.Now.AddMinutes(105)
                });
        }

        bool AddUserAndRole(LokalLive.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("editor"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "admin@lokallive.no",
            };
            ir = um.Create(user, "F0ssil3!52");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "editor");
            return ir.Succeeded;
        }
    }
}
