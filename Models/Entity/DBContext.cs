using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TECHNICAL_ASSESSMENT.Models.Entity
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new SeedData());
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
    }
}