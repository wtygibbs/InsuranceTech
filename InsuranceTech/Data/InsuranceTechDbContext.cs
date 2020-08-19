using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InsuranceTech.Models;

namespace InsuranceTech.Data
{
    public class InsuranceTechDbContext : DbContext
    {
        public InsuranceTechDbContext (DbContextOptions<InsuranceTechDbContext> options)
            : base(options)
        {
        }

        public DbSet<InsuranceTech.Models.Insurance> Insured { get; set; }
    }
}
