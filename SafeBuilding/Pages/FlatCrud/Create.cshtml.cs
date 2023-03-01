using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;

namespace SafeBuilding.Pages.FlatCrud
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
        ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "Id");
        ViewData["FlatTypeId"] = new SelectList(_context.FlatTypes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Flat Flat { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Flats.Add(Flat);
            await _context.SaveChangesAsync();

            return RedirectToPage("/FlatPage");
        }
    }
}
