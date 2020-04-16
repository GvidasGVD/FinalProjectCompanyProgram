using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectCompanyProgram.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityByExamples.Models.Configuration;

namespace FinalProjectCompanyProgram.Models
{
    //public class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }


        public DbSet<Door> Doors { get; set; }
    }
}
