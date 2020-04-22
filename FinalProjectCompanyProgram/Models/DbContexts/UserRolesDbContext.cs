using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCompanyProgram.Models.DbContexts
{
    public class UserRolesDbContext : DbContext
    {
        public UserRolesDbContext(DbContextOptions<UserRolesDbContext> options) : base(options)
        {

        }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
