using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDApp.Models;
using CRUDApp.Db.DbOperations;
namespace EF_CRUD_App.Controllers
{
	public class HomeController : Controller
	{
		EmployeeRepository employeeRepository = null;
		public HomeController()
		{
			employeeRepository = new EmployeeRepository();
		}
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(EmployeeModel employeeModel)
		{
			if(ModelState.IsValid)
			{
				int Id = employeeRepository.AddEmployee(employeeModel);
				if(Id > 0)
				{
					ModelState.Clear();
					ViewBag.Isuccess = "Data Added";
				}
			}
			return View();
		}

		public ActionResult GetAllEmployees()
		{
			var AllEmployees = employeeRepository.GetEmployees();
			var TotalEmployee = employeeRepository.GetTotalEmployee();
			ViewBag.TotalEmployees = TotalEmployee;
			return View(AllEmployees);
;		}

		public ActionResult Details(int id)
		{
			EmployeeModel EmoloyeeDetails = employeeRepository.GetEmployee(id);
			return View(EmoloyeeDetails);
		}

		public ActionResult Edit(int id)
		{
			EmployeeModel EmoloyeeDetails = employeeRepository.GetEmployee(id);
			return View(EmoloyeeDetails);
		}

		[HttpPost]
		public ActionResult Edit(EmployeeModel employeeModel)
		{
			if(ModelState.IsValid)
			{
				employeeRepository.UpdateEmployee(employeeModel.Id, employeeModel);
				return RedirectToAction("GetAllEmployees");
			}
			return View();
		}

		public ActionResult Delete(int id = -1)
		{
			if(id == -1)
				return RedirectToAction("GetAllEmployees");
			EmployeeModel EmoloyeeDetails = employeeRepository.GetEmployee(id);
			return View(EmoloyeeDetails);
		}
		[HttpPost]
		public ActionResult Delete(int id, EmployeeModel employeeModel)
		{
			employeeRepository.DeleteEmployee(id);
			return RedirectToAction("GetAllEmployees");
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		                                
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}