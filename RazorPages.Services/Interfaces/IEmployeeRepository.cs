using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Services.Interfaces
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> Select();
		Employee GetById(int id);

		Employee Update(Employee updatedEmployee);

		Employee Delete(int id);
	}
}
