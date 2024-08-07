using System.ComponentModel;

namespace RepositoryPatternExample.Models
{
	public class Employee
	{
		[DisplayName("EmpId")]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }

	}
}
