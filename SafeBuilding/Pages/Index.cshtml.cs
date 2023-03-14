using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Repository.Models;
using System.Collections.Generic;
using System.Text;

namespace SafeBuilding.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Invoice> Invoices { get; set; }

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


        [HttpGet]
        IActionResult Index(List<Invoice> invoice = null)
        {
            invoice = invoice == null ? new List<Invoice>() : invoice;
            return Page();
        }
        //[HttpPost]
        //IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        //{
        //    string filename = $"{hostingEnvironment.WebRootPath}\\file\\{file.FileName}";
        //    using (FileStream fileStream = System.IO.File.Create(filename))
        //    {
        //        file.CopyTo(fileStream);
        //        fileStream.Flush();
        //    }
        //    var invoice = this.GetInvoiceList(file.FileName);
        //    return Page();
        //}

        public IActionResult OnPostUploadFile(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            string filename = $"{hostingEnvironment.WebRootPath}\\file\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(filename))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var invoice = this.GetInvoiceList(file.FileName);
            return Page();
        }

        private List<Invoice> GetInvoiceList(string fName)
        {
            List<Invoice> list = new List<Invoice>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\file"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        list.Add(new Invoice()
                        {
                            rent = reader.GetValue(0).ToString(),
                            water = reader.GetValue(1).ToString(),
                            electicity = reader.GetValue(2).ToString(),
                            management = reader.GetValue(3).ToString(),
                            parking = reader.GetValue(4).ToString(),
                            email = reader.GetValue(5).ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}