﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;

namespace SafeBuilding.Pages.FlatTypeCrud
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
            return Page();
        }

        [BindProperty]
        public FlatType FlatType { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FlatTypes.Add(FlatType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./FlatTypePage");
        }
    }
}
