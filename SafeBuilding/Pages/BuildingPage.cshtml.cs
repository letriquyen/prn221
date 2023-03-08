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
    public class IndexModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public IndexModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public IList<Building> Building { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string searchString)
        {
            if (HttpContext.Session.GetString("Phone") == null)
            {
                return RedirectToPage("Login");
            }
            else
            if (_context.Buildings != null)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    CurrentFilter = searchString;
                    Building = await _context.Buildings.Where(s => s.Name.Contains(CurrentFilter)).ToListAsync();
                }
                else
                    Building = await _context.Buildings.ToListAsync();
            }
            return Page();
        }
    }
}
