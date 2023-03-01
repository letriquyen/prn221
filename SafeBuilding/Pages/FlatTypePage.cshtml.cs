using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.FlatTypeCrud
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public IndexModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        public IList<FlatType> FlatType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FlatTypes != null)
            {
                FlatType = await _context.FlatTypes.ToListAsync();
            }
        }
    }
}
