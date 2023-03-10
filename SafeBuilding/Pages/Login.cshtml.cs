using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace SafeBuilding.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Admin admin { get; set; }
        [BindProperty]
        public string message { get; set; }
        private readonly AdminRepository _repository;
        public LoginModel(AdminRepository repository)
        {
            _repository = repository;
        }
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return Page();
        }

        public IActionResult OnPost()
        {
            var check = _repository.GetAll()
                        .Where(p => p.Phone.Equals(admin.Phone)
                        && p.Password.Equals(admin.Password)).FirstOrDefault();
            if(check != null)
            {
                HttpContext.Session.SetString("Phone", check.Phone);
                return RedirectToPage("Index");
            }
            else
            {
                message = "Permission denied";
                return Page();
            }
        }
    }
}
