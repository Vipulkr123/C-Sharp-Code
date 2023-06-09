
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectionOperator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Using Query Syntax
			List<Employee> basicQuery = (from emp in Employee.GetEmployees()
										 where emp.Salary > 80000
										 orderby emp.Salary descending
										 select emp).ToList();

			foreach (Employee emp in basicQuery)
			{
				Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
			}

            Console.WriteLine("---------------------------------------");

            //Using Method Syntax
            IEnumerable<Employee> basicMethod = Employee.GetEmployees().Where(e => e.Salary > 90000).OrderByDescending(e => e.ID).ToList();
			foreach (Employee emp in basicMethod)
			{
				Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
			}

			// FInd 2nd highest salary
			var Result = Employee.GetEmployees().OrderByDescending(e => e.Salary).Take(2).OrderBy(e => e.Salary).Select(e => e.FirstName).First();
            Console.WriteLine(Result);
			// 2nd way to find 2nd highest salary
			//Annonymous type new {employee.ID.....}
			var employee = Employee.GetEmployees().OrderByDescending(e => e.Salary).Skip(1).Take(1).Select(employee => new { employee.ID, employee.FirstName, employee.Salary}).ToList();
			//Console.WriteLine(employee);

			Console.Write(employee[0].ID + " " + employee[0].FirstName + " " + employee[0].Salary);
            Console.WriteLine();

			// Multiple value second highest
            //var employees = Employee.GetEmployees().GroupBy(e => e.Salary).OrderByDescending(e => e.Key).Select(e => e.Nam).Skip(1).First();
			//Console.WriteLine(employees.Key);

			// Index
			var selectMethod = Employee.GetEmployees().Select((emp, index) => new {Index = index, EmployeeID = emp.ID, EmployeeFirstName = emp.FirstName, EmployeeSalary = emp.Salary}).ToList();
            foreach (var item in selectMethod)
            {
                Console.WriteLine($"Employee id : {item.EmployeeID} Employee Name : {item.EmployeeFirstName} Salary : {item.EmployeeSalary}");
            }

			// SelectMany 
			var selectManyMethod = Employee.GetEmployees().Where(emp => emp.LastName == "Kumar").SelectMany(emp => emp.FirstName).ToList();
			foreach (var item in selectManyMethod)
			{ 
				Console.Write(item + " "); 
			}

            Console.ReadKey();
		}
	}
}