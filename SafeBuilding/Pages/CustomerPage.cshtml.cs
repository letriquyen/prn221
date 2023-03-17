using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.CustomerCrud
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public IndexModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public IList<Customer> Customer { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(String searchString)
        {
            if (HttpContext.Session.GetString("Phone") == null)
            {
                return RedirectToPage("Login");
            }
            else
            if (_context.Customers != null)
            {

                if (!String.IsNullOrEmpty(searchString))
                {
                    CurrentFilter = searchString;
                    Customer = await _context.Customers.Where(s => s.Fullname.Contains(CurrentFilter)).ToListAsync();
                }
                else
                    Customer = await _context.Customers.ToListAsync();
            }
            return Page();
        }
    }
}
