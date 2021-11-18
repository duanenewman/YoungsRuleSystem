using Amendment.Server.Model.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amendment.Server.Repository
{
    public class AmendmentContext : DbContext
    {
        internal AmendmentContext(DbContextOptions<AmendmentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Role adminRole = new Role()
            {
                Id = 1,
                Name = "System Administrator",
                EnteredBy = -1,
                EnteredDate = DateTime.Parse("2018-01-01"),
                LastUpdatedBy = -1,
                LastUpdated = DateTime.Parse("2018-01-01"),
            };
            Role toastRole = new Role()
            {
                Id = 5,
                Name = "Toast Notifications",
                EnteredBy = -1,
                EnteredDate = DateTime.Parse("2018-01-01"),
                LastUpdatedBy = -1,
                LastUpdated = DateTime.Parse("2018-01-01"),
            };

            builder.Entity<Role>()
                .HasData(adminRole,
                new Role()
                {
                    Id = 2,
                    Name = "Screen Controller",
                    EnteredBy = -1,
                    EnteredDate = DateTime.Parse("2018-01-01"),
                    LastUpdatedBy = -1,
                    LastUpdated = DateTime.Parse("2018-01-01"),
                },
                new Role()
                {
                    Id = 3,
                    Name = "Amendment Editor",
                    EnteredBy = -1,
                    EnteredDate = DateTime.Parse("2018-01-01"),
                    LastUpdatedBy = -1,
                    LastUpdated = DateTime.Parse("2018-01-01"),
                },
                new Role()
                {
                    Id = 4,
                    Name = "Translator",
                    EnteredBy = -1,
                    EnteredDate = DateTime.Parse("2018-01-01"),
                    LastUpdatedBy = -1,
                    LastUpdated = DateTime.Parse("2018-01-01"),
                },
                toastRole);

            builder.Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@admin.com",
                    Name = "Admin",
                    Password = "$2b$12$HbvEC6UaeXiGGlv8ztvzL.SB6oBXKi2QoBkJsjwQvDJGpQ59CmWrq",
                    EnteredBy = -1,
                    EnteredDate = DateTime.Parse("2018-01-01"),
                    LastUpdatedBy = -1,
                    LastUpdated = DateTime.Parse("2018-01-01"),
                    Roles = new List<Role> { adminRole, toastRole }
                });
            base.OnModelCreating(builder);
        }
    }
}
