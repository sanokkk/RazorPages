using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services.Interfaces;

namespace RazorPages.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _db;
        public DeleteModel(IEmployeeRepository db)
        {
            _db = db;
        }
        [BindProperty]
        public Employee employee { get; set; }

        public IActionResult OnGet(int id)
        {
            employee = _db.GetById(id);
            if (employee == null) return RedirectToPage("/NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            Employee employeeToDelete = _db.Delete(employee.Id);
            if (employeeToDelete == null) return RedirectToPage("/NotFound");
            return Redirect("/Employees/Employees");
        }
    }
}
