using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProjectCompanyProgram.Models;

namespace FinalProjectCompanyProgram.Data
{
    public class FinalProjectCompanyProgramContext : DbContext
    {
        public FinalProjectCompanyProgramContext (DbContextOptions<FinalProjectCompanyProgramContext> options)
            : base(options)
        {
        }

        public DbSet<Door> Door { get; set; }
    }
}
