using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services.Interfaces;
using System;
using System.IO;

namespace RazorPages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EditModel(IEmployeeRepository db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
        }
        [BindProperty]
        public Employee Employee { get; set; }
		[BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }


        public IActionResult OnGet(int id)
        {
            Employee = _db.GetById(id);
            if (Employee == null) return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
		{
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", Employee.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    Employee.PhotoPath = FileUpload();
                }

                Employee = _db.Update(Employee);
                return RedirectToPage("Employees");
            }
            return Page();
            
		}

        private string FileUpload()
		{
            string uniqueFileName = null;
            if (Photo != null)
			{
                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(folder, uniqueFileName);
                
                
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
		}
    }
}
