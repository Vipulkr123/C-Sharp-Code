using System.Collections.Generic;
namespace SortingOperatorLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Orderby Method
			var dataSource = new List<int> { 12, 7, 1, 9, 35, 4, 26, 90, 32 };
			var OrderByMethod = dataSource.OrderBy(x => x);
            foreach (var item in OrderByMethod)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------");

            // OrderByDescending Method 
            var OrderBydescendingMethod = dataSource.OrderByDescending(x => x).ToList();
            foreach (var item in OrderBydescendingMethod)
            {
                Console.Write(item + " ");
            }

			Console.WriteLine();
			Console.WriteLine("---------------------------");

			//ThenBy
			var ThenByMethod = Employee.GetEmployees().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
			foreach (var item in ThenByMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.FirstName} {item.LastName} Salary : {item.Salary}");
			}

			Console.WriteLine();
			Console.WriteLine("---------------------------");

			// ThenByDescending Method
			var ThenByDescendingMethod = Employee.GetEmployees().OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
			foreach (var item in ThenByDescendingMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.FirstName} {item.LastName} Salary : {item.Salary}");
			}

			Console.WriteLine();
			Console.WriteLine("---------------------------");

			//Reverse Method
			var ReverseMethod = dataSource.AsEnumerable().Reverse();
			foreach (var item in ReverseMethod)
			{
				Console.Write(item + " ");
			}
		}
	}
}