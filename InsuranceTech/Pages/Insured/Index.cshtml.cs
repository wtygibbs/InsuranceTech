using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InsuranceTech.Data;
using InsuranceTech.Models;

namespace InsuranceTech.Pages.Insured
{
    public class IndexModel : PageModel
    {
        private readonly InsuranceTech.Data.InsuranceTechDbContext _context;

        public IndexModel(InsuranceTech.Data.InsuranceTechDbContext context)
        {
            _context = context;
        }

        public IList<Insurance> Insurance { get; set; }

        public async Task OnGetAsync()
        {
            Insurance = await _context.Insured.ToListAsync();
        }
    }
}
