using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.FacilityCrud
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public DeleteModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Facility Facility { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities.FirstOrDefaultAsync(m => m.Id == id);

            if (facility == null)
            {
                return NotFound();
            }
            else 
            {
                Facility = facility;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Facilities == null)
            {
                return NotFound();
            }
            var facility = await _context.Facilities.FindAsync(id);

            if (facility != null)
            {
                Facility = facility;
                _context.Facilities.Remove(Facility);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/FacilityPage");
        }
    }
}
