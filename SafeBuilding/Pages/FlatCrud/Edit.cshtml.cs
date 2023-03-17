using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.FlatCrud
{
    public class EditModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public EditModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flat Flat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Flats == null)
            {
                return NotFound();
            }

            var flat =  await _context.Flats.FirstOrDefaultAsync(m => m.Id == id);
            if (flat == null)
            {
                return NotFound();
            }
            Flat = flat;
           ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "Name");
           ViewData["FlatTypeId"] = new SelectList(_context.FlatTypes, "Id", "Name");
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

            _context.Attach(Flat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatExists(Flat.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/FlatPage");
        }

        private bool FlatExists(string id)
        {
          return _context.Flats.Any(e => e.Id == id);
        }
    }
}
