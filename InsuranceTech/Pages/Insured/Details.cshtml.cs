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
    public class DetailsModel : PageModel
    {
        private readonly InsuranceTech.Data.InsuranceTechDbContext _context;

        public DetailsModel(InsuranceTech.Data.InsuranceTechDbContext context)
        {
            _context = context;
        }

        public Insurance Insurance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insurance = await _context.Insured.FirstOrDefaultAsync(m => m.ID == id);

            if (Insurance == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
