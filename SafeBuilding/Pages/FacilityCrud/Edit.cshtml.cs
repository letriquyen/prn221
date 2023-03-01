using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.FacilityCrud
{
    public class EditModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public EditModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Facility Facility { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility =  await _context.Facilities.FirstOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }
            Facility = facility;
           ViewData["FlatId"] = new SelectList(_context.Flats, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(Facility.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/FacilityPage");
        }

        private bool FacilityExists(string id)
        {
          return _context.Facilities.Any(e => e.Id == id);
        }
    }
}
