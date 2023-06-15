using System.Linq;
using System.Web.Mvc;

namespace DatabaseFirst.Controllers
{
	public class StudentController : Controller
	{
		Testdb testdb = new Testdb();
		public ActionResult Student(Student obj)
		{
			if (obj != null)
			{
				return View(obj);
			}
			else
			{
				return View();
			}
		}

		[HttpPost]
		public ActionResult AddStudent(Student model)
		{
			if (ModelState.IsValid)
			{
				Student student = new Student();
				var studentList = testdb.Students.ToList();
				if (!studentList.Any(x => x.Id == model.Id))
				{
					student.Id = model.Id;
					student.Name = model.Name;
					student.Email = model.Email;
					student.Mobile = model.Mobile;
					student.Address = model.Address;
					testdb.Students.Add(student);
				}
				else
				{
					var studentSelect = testdb.Students.FirstOrDefault(x => x.Id == model.Id);
					studentSelect.Name = model.Name;
					studentSelect.Email = model.Email;
					studentSelect.Mobile = model.Mobile;
					studentSelect.Address = model.Address;
				}
				testdb.SaveChanges();
			}
			ModelState.Clear();
			return View("Student");
		}

		public ActionResult StudentList()
		{
			var studentList = testdb.Students.ToList();
			return View(studentList);
		}

		public ActionResult Delete(int id)
		{
			var student = testdb.Students.Where(stud => stud.Id == id).FirstOrDefault();
			if (student != null)
			{
				testdb.Students.Remove(student);
				testdb.SaveChanges();
			}
			var studentList = testdb.Students.ToList();
			return View("StudentList", studentList);
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