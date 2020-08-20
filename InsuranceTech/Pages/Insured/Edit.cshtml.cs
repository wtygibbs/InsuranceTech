using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsuranceTech.Data;
using InsuranceTech.Models;

namespace InsuranceTech.Pages.Insured
{
    public class EditModel : PageModel
    {
        private readonly InsuranceTech.Data.InsuranceTechDbContext _context;

        public EditModel(InsuranceTech.Data.InsuranceTechDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Insurance.Premium = Insurance.calculatePremium(Insurance.State, Insurance.TotalInsuredValue, Insurance.Rate);
            Insurance.TRIAPremium = Insurance.calculateTriaPremium(Insurance.Premium);
            _context.Attach(Insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(Insurance.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InsuranceExists(int id)
        {
            return _context.Insured.Any(e => e.ID == id);
        }
    }
}
