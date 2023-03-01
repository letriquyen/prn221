using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.RentContractCrud
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public DeleteModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RentContract RentContract { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.RentContracts == null)
            {
                return NotFound();
            }

            var rentcontract = await _context.RentContracts.FirstOrDefaultAsync(m => m.Id == id);

            if (rentcontract == null)
            {
                return NotFound();
            }
            else 
            {
                RentContract = rentcontract;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.RentContracts == null)
            {
                return NotFound();
            }
            var rentcontract = await _context.RentContracts.FindAsync(id);

            if (rentcontract != null)
            {
                RentContract = rentcontract;
                _context.RentContracts.Remove(RentContract);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/RentContractPage");
        }
    }
}
