using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Interfaces;
using RepositoryPatternExample.Models;

namespace RepositoryPatternExample.Controllers
{
    public class EmployeeCopyController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeCopyController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var result = _employeeRepository.GetAllEmployee();
            return View(result);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Edit(int id) 
        {
           var result =  _employeeRepository.GetEmployee(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee) 
        {
            if (ModelState.IsValid) 
            {
                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            var result = _employeeRepository.GetEmployee(id);
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
          var deleteemployee = _employeeRepository.DeleteEmployee(id);
            if (deleteemployee != null) 
            {
                return RedirectToAction("Index");
            }
            return View(deleteemployee);

        }
    }
}
