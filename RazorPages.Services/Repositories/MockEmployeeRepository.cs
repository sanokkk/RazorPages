using RazorPages.Models;
using RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPages.Services.Repositories
{
	public class MockEmployeeRepository : IEmployeeRepository
	{
		private List<Employee> Employees;
		public MockEmployeeRepository()
		{
			Employees = new List<Employee>()
			{
				new Employee()  { Id = 0, Name = "Alex", Email = "sashaevstr2002@yandex.ru", PhotoPath = "Sasha.jpg", Department = Dept.IT },
				new Employee()  { Id = 1, Name = "Andrey", Email = "andrei200287@gmail.com", PhotoPath =  "Andrey.jpg", Department = Dept.HR },
				new Employee()  { Id = 2, Name = "Amir", Email = "amirmukumov@gmail.com", PhotoPath = "Amir.jpg", Department = Dept.Payroll } 
			};
		}

        public Employee Delete(int id)
		{
			var deletedItem = Employees.FirstOrDefault(x => x.Id == id);
			if (deletedItem != null)
				Employees.Remove(deletedItem);
			return deletedItem;
        }

        public Employee GetById(int id)
        {
            return Employees.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> Select()
		{
			return Employees;
		}

		public Employee Update(Employee updatedEmployee)
		{
			Employee employee = Employees.FirstOrDefault(x => x.Id == updatedEmployee.Id);

			if (employee != null)
			{
				employee.Name = updatedEmployee.Name;
				employee.Email = updatedEmployee.Email;
				employee.PhotoPath = updatedEmployee.PhotoPath;
				employee.Department = updatedEmployee.Department;
			}
			return employee;
		}
	}
}
