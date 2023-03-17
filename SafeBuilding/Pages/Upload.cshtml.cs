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
    public class UploadModel : PageModel
    {

        public IEnumerable<Invoice> Invoices { get; set; }

        private readonly ILogger<UploadModel> _logger;

        public UploadModel(ILogger<UploadModel> logger)
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

        public IActionResult OnPost(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            string filename = Path.Combine(hostingEnvironment.WebRootPath, "file", file.FileName);
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

            var Email = new MimeMessage();
            List<Invoice> list = new List<Invoice>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\file"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string rent = reader.GetValue(0).ToString();
                        string water = reader.GetValue(1).ToString();
                        string electicity = reader.GetValue(2).ToString();
                        string management = reader.GetValue(3).ToString();
                        string parking = reader.GetValue(4).ToString();
                        string email = reader.GetValue(5).ToString();
                        string mainBody = "<tr>" +
                                                "<th>" + reader.GetValue(0).ToString() + "</th>"+
                                                "<th>" + reader.GetValue(1).ToString() + "</th>" +
                                                "<th>" + reader.GetValue(2).ToString() + "</th>" +
                                                "<th>" + reader.GetValue(3).ToString() + "</th>" +
                                                "<th>" + reader.GetValue(4).ToString() + "</th>" +
                                            "</tr>";
                        string body = "<html><head></head><body>" +
                @"<table border=""1"" cellpadding=""5"" style=""border-collapse: collapse;""><tr style=""color:white;background-Color:SkyBlue;font-weight:bold;"">" +
                "<td>Rent</td><td>Water</td><td>Electricity</td><td>Management</td><td>Parking</td>" + "</tr>" + mainBody + "</table></body></html>";
                        Email.From.Add(MailboxAddress.Parse("safebuilding76@gmail.com"));
                        Email.To.Add(MailboxAddress.Parse(email));
                        Email.Subject = "New Invoice from SafeBuilding";
                        Email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };
                        using var smtp = new SmtpClient();
                        smtp.Connect("smtp.gmail.com", 465, true);
                        smtp.Authenticate("safebuilding76@gmail.com", "afcllbwpxmsebrnw");
                        smtp.Send(Email);
                        smtp.Disconnect(true);
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