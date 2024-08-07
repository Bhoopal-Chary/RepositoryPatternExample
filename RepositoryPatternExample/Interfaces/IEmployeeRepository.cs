using RepositoryPatternExample.Models;

namespace RepositoryPatternExample.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
       Employee InsertEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }
}
