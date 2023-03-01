using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.BuildingCrud
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public DeleteModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Building Building { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.FirstOrDefaultAsync(m => m.Id == id);

            if (building == null)
            {
                return NotFound();
            }
            else 
            {
                Building = building;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }
            var building = await _context.Buildings.FindAsync(id);

            if (building != null)
            {
                Building = building;
                _context.Buildings.Remove(Building);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/BuildingPage");
        }
    }
}
