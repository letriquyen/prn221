using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.FlatTypeCrud
{
    public class EditModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public EditModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FlatType FlatType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.FlatTypes == null)
            {
                return NotFound();
            }

            var flattype =  await _context.FlatTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (flattype == null)
            {
                return NotFound();
            }
            FlatType = flattype;
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

            _context.Attach(FlatType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatTypeExists(FlatType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/FlatTypePage");
        }

        private bool FlatTypeExists(string id)
        {
          return _context.FlatTypes.Any(e => e.Id == id);
        }
    }
}
