 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPages.Models
{
	public class Employee
	{
		public int Id { get; set; }

        [Required(ErrorMessage ="Can't be NULL")]
		public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Incorrect mail")]
		public string Email { get; set; }
        
		public string PhotoPath { get; set; }
		public Dept? Department { get; set; }
	}
}
