using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;

namespace SafeBuilding.Pages.RentContractCrud
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
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Fullname");
        ViewData["FlatId"] = new SelectList(_context.Flats, "Id", "RoomNumber");
            return Page();
        }

        [BindProperty]
        public RentContract RentContract { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RentContracts.Add(RentContract);
            await _context.SaveChangesAsync();

            return RedirectToPage("/RentContractPage");
        }
    }
}
