
namespace JoinsLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Select Date Between 
			var NewQuery = Data.EmpList.Where(emp => emp.Gender == "Male");

			foreach (var item in NewQuery)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.Name} Date of Birth : {item.DOB}");
			}
			#endregion Date Between

			#region Inner Join
			var MyEmp = Data.EmpList.Where(emp => emp.DOB > DateOnly.Parse("09-02-1999") && emp.DOB < DateOnly.Parse("15-04-2006"));

			foreach (var item in MyEmp)
			{
				Console.WriteLine(item.Name);
			}
			// Using Query Syntax
			var InnerJoin = (from emp in Data.EmpList
							 join dept in Data.DeptList
							 on emp.DeptId equals dept.ID
							 select new
							 {
								 EmployeeName = emp.Name,
								 EmployeeDOB = emp.DOB,
								 DepartmentName = dept.Name
							 }).ToList();

			foreach (var item in InnerJoin)
			{
				Console.WriteLine($"Name : {item.EmployeeName} Employee Dob : {item.EmployeeDOB} Department Name : {item.DepartmentName}");
			}

			Console.WriteLine("======= Using lamda Expression ========");

			// Using Lamda Expression
			var InnerJoinLamda = Data.EmpList.Join(Data.DeptList,
												emp => emp.DeptId,
												dept => dept.ID,
												(emp, dept) => new
												{
													EmployeeName = emp.Name,
													EmployeeDOB = emp.DOB,
													DepartmentName = dept.Name
												}).ToList();

			foreach (var item in InnerJoinLamda)
			{
				Console.WriteLine($"Name : {item.EmployeeName} Employee Dob : {item.EmployeeDOB} Department Name : {item.DepartmentName}");
			}
			#endregion InnerJoin 

			Console.WriteLine("-----------Inner join------------");

			#region Multiple Inner Joins
			var querySyntax = (from emp in Data.EmpList
							   join dept in Data.DeptList
							   on emp.DeptId equals dept.ID
							   join leavels in Data.LeaveList
							   on dept.ID equals leavels.EmpId
							   select new
							   {
								   EmployeeName = emp.Name,
								   EmployeeDOB = emp.DOB,
								   DepartmentName = dept.Name,
								   LeaveReason = leavels.Reason
							   }).ToList();

			foreach (var item in querySyntax)
			{
				Console.WriteLine($"Name : {item.EmployeeName} Employee Dob : {item.EmployeeDOB} Department Name : {item.DepartmentName} Reason : {item.LeaveReason}");
			}

			Console.WriteLine("using Lamda expression");

			// Using Lamda Expression

			var UsingMethods = Data.EmpList.Join(Data.DeptList,
												 emp => emp.DeptId,
												 dept => dept.ID,
												 (emp, dept) =>
												 new { emp, dept })
											.Join(Data.LeaveList,
													dept => dept.emp.ID,
													leave => leave.EmpId,
													(dept, leave) => new
													{
														EmployeeName = dept.emp.Name,
														EmployeeDOB = dept.emp.DOB,
														DepartmentName = dept.dept.Name,
														LeaveReason = leave.Reason
													}).ToList();
			foreach (var item in UsingMethods)
			{
				Console.WriteLine($"Name : {item.EmployeeName} Employee Dob : {item.EmployeeDOB} Department Name : {item.DepartmentName} Reason : {item.LeaveReason}");
			}
			#endregion Multiple Inner Joins 

			#region Second Highest Salary
			// Second Highest salary 
			var scndHighestSal = Data.EmpList.OrderByDescending(s => s.Salary).Select(emp => emp.Salary).Distinct().Skip(1).First();
			var sc = Data.EmpList.Select(e => e.Salary == scndHighestSal).ToList();

			var htsc = Data.EmpList.OrderByDescending(emp => emp.Salary).GroupBy(emp => emp.Salary).Skip(1).First();

			Console.WriteLine("--------------");
			foreach (var item in htsc)
			{
				Console.WriteLine(item.Name);
			}
			#endregion Second Highest Salary

			Console.WriteLine("----------Group Join-------------");

			#region Group Join

			var GroupJoinByQuery = from dept in Data.DeptList
								   join emp in Data.EmpList
								   on dept.ID equals emp.DeptId
								   into deptGroup
								   select new { dept, deptGroup };

			foreach (var item in GroupJoinByQuery)
			{
				Console.WriteLine($"\n{item.dept.Name} =>");
				foreach (var item1 in item.deptGroup)
				{
					Console.Write(item1.Name + " ");
				}
			}

			Console.WriteLine("\n\n=========================================");

			var GroupJoinMethod = Data.DeptList.GroupJoin(Data.EmpList,
														  dept => dept.ID,
														  emp => emp.DeptId,
														  (dept, emp) => new
														  {
															  dept,
															  emp
														  });

			foreach (var item in GroupJoinMethod)
			{
				Console.WriteLine($"\n{item.dept.Name} =>");
				foreach (var item1 in item.emp)
				{
					Console.Write(item1.Name + " ");
				}
			}

			#endregion Group Join

			Console.WriteLine("\n----------Left Join-------------\n");

			#region Left Join

			var qs = (from emp in Data.EmpList
					 join dept in Data.DeptList
					 on emp.DeptId equals dept.ID
					 into empGroup
					 from empl in empGroup.DefaultIfEmpty()
					 select new {
						 Name = emp.Name,					 
						 Salary = emp.Salary,
						 DepartmentName = empl != null ? empl.Name : "NA"
					 }).ToList();

            foreach (var item in qs)
            {
                Console.WriteLine($"{item.Name} Salary : {item.Salary} Department Name : {item.DepartmentName}");
            }

			Console.WriteLine("\n=========================================\n");

			var le = Data.EmpList.GroupJoin(Data.DeptList,
									   emp => emp.DeptId,
									   dept => dept.ID,
									   (emp, dept) => new
									   {
										   emp, dept
									   }).SelectMany(x => x.dept.DefaultIfEmpty(), (emp, dept) => new { emp, dept = dept != null ? dept.Name : "NA" }).ToList();


			foreach (var item in le)
			{
				Console.WriteLine($"{item.emp.emp.Name} Salary : {item.emp.emp.Salary} Department Name : {item.dept}");
			}
			#endregion Left Join

		}
	}
}