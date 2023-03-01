using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;

namespace SafeBuilding.Pages.FacilityCrud
{
    public class CreateModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public CreateModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FlatId"] = new SelectList(_context.Flats, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Facility Facility { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Facilities.Add(Facility);
            await _context.SaveChangesAsync();

            return RedirectToPage("/FacilityPage");
        }
    }
}
