using CodeFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CodeFirstDemo.Controllers
{
	public class HomeController : Controller
	{
		DataContext _dataContext = new DataContext();	
		public ActionResult Index()
		{
			var data = _dataContext.Employees.ToList();
			return View(data);
		}

		public ActionResult Details(int id)
		{
			var data = _dataContext.Employees.Where(emp => emp.EmpId == id).SingleOrDefault();
			return View(data);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Employee employee)
		{
			try
			{
				List<object> lists = new List<object>();

				lists.Add(employee.Name);
				lists.Add(employee.Dept);
				lists.Add(employee.Salary);

				object[] allItems = lists.ToArray();
				int output = _dataContext.Database.ExecuteSqlCommand("Insert into Employees (Name, Dept, Salary) Values (@p0,@p1,@p2)", allItems);
				if(output > 0)
				{
					ViewBag.msg = "Employee Added Successfully";
				}
				else
				{
					ViewBag.msg = "Error try Again !";
				}
				return RedirectToAction("Index");
			}
			catch 
			{

				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			var data = _dataContext.Employees.Where(emp => emp.EmpId == id).SingleOrDefault();
			return View(data);
		}

		[HttpPost]
		public ActionResult Edit(int id, Employee employee)
		{
			try
			{
				List<object> lists = new List<object>();

				lists.Add(employee.Name);
				lists.Add(employee.Dept);
				lists.Add(employee.Salary);

				object[] allItems = lists.ToArray();
				int output = _dataContext.Database.ExecuteSqlCommand($"Update Employees set Name = @p0, Dept = @p1, Salary = @p2 where EmpId = {id}", allItems);
				if (output > 0)
				{
					ViewBag.msg = "Employee Updated Successfully";
				}
				else
				{
					ViewBag.msg = "Error try Again !";
				}
				return RedirectToAction("Index");
			}
			catch 
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			var data = _dataContext.Employees.Where(emp => emp.EmpId == id).SingleOrDefault();
			return View(data);
		}

		[HttpPost]
		public ActionResult Delete(int id, Employee employee)
		{
			try
			{
				int output = _dataContext.Database.ExecuteSqlCommand($"Delete From Employees Where EmpId = {id}");
				if (output != 0)
				{
					ViewBag.msg = "Employee Deleted Successfully";
				}
				else
				{
					ViewBag.msg = "Error try Again !";
				}
				return RedirectToAction("Index");
			}
			catch
			{

				return View();
			}
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