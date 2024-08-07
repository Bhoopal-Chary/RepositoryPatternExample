using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using RepositoryPatternExample.Data;
using RepositoryPatternExample.Interfaces;
using RepositoryPatternExample.Models;

namespace RepositoryPatternExample.Services
{
	public class EmployeeService : IEmployeeRepository
	{
		private ApplicationDbContext _db;
		private readonly ILoggerHelper _logger;
		public EmployeeService(ApplicationDbContext db, ILoggerHelper logger)
		{
			_db = db;
			_logger = logger;
		}
		public Employee DeleteEmployee(int id)
		{
			var employee = _db.Employees.Find(id);
			if (employee == null)
			{
				return null;
			}

			_db.Employees.Remove(employee);
			_db.SaveChanges();
			return employee;
		}

		public List<Employee> GetAllEmployee()
		{
			try
			{
				int a = 100, b = 0;
				int c = a / b;
			}
			catch (Exception ex)
			{

				_logger.LogError(ex.Message);
			}
			return _db.Employees.ToList();
		}

		public Employee GetEmployee(int id)
		{
			return _db.Employees.Find(id);
		}

		public Employee InsertEmployee(Employee employee)
		{
			try
			{
				_db.Employees.Add(employee);
				_db.SaveChanges();
				return employee;
			}
			catch (Exception ex)
			{

				_logger.LogError(ex.Message);
			}
			return new Employee();
		}

		public Employee UpdateEmployee(Employee employee)
		{
			_db.Employees.Update(employee);
			_db.SaveChanges();
			return employee;
		}
	}
}
