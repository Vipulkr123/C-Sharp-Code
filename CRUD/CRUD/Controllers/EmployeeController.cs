using CRUD.DataAccessLayer;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Employees_DAL _dal;

        public EmployeeController(Employees_DAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _dal.GetAll();
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
            }
            return View(employees);
        }
    }
}
