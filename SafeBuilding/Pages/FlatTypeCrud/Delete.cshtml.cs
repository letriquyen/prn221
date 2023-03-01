﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace SafeBuilding.Pages.FlatTypeCrud
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Models.SafeBuildingContext _context;

        public DeleteModel(Repository.Models.SafeBuildingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FlatType FlatType { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.FlatTypes == null)
            {
                return NotFound();
            }

            var flattype = await _context.FlatTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (flattype == null)
            {
                return NotFound();
            }
            else 
            {
                FlatType = flattype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.FlatTypes == null)
            {
                return NotFound();
            }
            var flattype = await _context.FlatTypes.FindAsync(id);

            if (flattype != null)
            {
                FlatType = flattype;
                _context.FlatTypes.Remove(FlatType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/FlatTypePage");
        }
    }
}
