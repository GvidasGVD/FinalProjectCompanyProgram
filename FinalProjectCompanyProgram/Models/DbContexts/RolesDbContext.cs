using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCompanyProgram.Models
{
    public class RolesDbContext : DbContext
    {
        public RolesDbContext(DbContextOptions<RolesDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
    }
}
