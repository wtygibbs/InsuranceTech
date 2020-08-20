using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InsuranceTech.Data;
using InsuranceTech.Models;

namespace InsuranceTech.Pages.Insured
{
    public class CreateModel : PageModel
    {
        private readonly InsuranceTech.Data.InsuranceTechDbContext _context;

        public CreateModel(InsuranceTech.Data.InsuranceTechDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Insurance Insurance { get; set; }

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

            _context.Insured.Add(Insurance);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
