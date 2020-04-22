using FinalProjectCompanyProgram.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectCompanyProgram.Models
{
    //public class ApplicationDbContext : DbContext

    //class now inherits from the IdentityDbContext class 
    //and not DbContext - to integrate context with Identity.
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }
        // ModelBuilder is required for the migration to work properly.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }


        public DbSet<Door> Doors { get; set; }
    }
}
