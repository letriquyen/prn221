using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.RentContractCrud
{
    public class EditModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public EditModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RentContract RentContract { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.RentContracts == null)
            {
                return NotFound();
            }

            var rentcontract =  await _context.RentContracts.FirstOrDefaultAsync(m => m.Id == id);
            if (rentcontract == null)
            {
                return NotFound();
            }
            RentContract = rentcontract;
           ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
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

            _context.Attach(RentContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentContractExists(RentContract.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/RentContractPage");
        }

        private bool RentContractExists(string id)
        {
          return _context.RentContracts.Any(e => e.Id == id);
        }
    }
}
