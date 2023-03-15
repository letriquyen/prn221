using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Repository.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MailKit.Net.Smtp;
using System.Diagnostics.Metrics;

namespace SafeBuilding.Pages
{
    public class IndexModel : PageModel
    {


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Phone") == null)
            {
                return RedirectToPage("Login");
            }
            return Page();
        }


    }
}