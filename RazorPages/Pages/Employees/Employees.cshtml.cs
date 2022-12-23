using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RazorPages.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;
		public EmployeesModel(IEmployeeRepository db)
		{
			_db = db;
		}

        public IEnumerable<Employee> Employees { get; set; }

		public void OnGet()
        {
            Employees = _db.Select();
        }

        
    }
}
