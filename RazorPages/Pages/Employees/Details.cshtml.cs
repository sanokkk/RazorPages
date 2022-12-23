using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services.Interfaces;

namespace RazorPages.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _db;
        public DetailsModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public Employee employee { get; set; }

        public IActionResult OnGet(int id)
        {
            employee = _db.GetById(id);
            if (employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            else return Page();
        }
    }
}
