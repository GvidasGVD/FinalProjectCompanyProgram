using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCompanyProgram.Models
{
    public class Role
    {
        public int Id { get; }
        public string Name { get;}
        public string NormalizedName { get; }
    }
}
