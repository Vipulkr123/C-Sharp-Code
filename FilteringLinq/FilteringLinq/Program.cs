namespace FilteringLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// OfType Method
			var FilterOfType = Employee.GetEmployees().OfType<Employee>().ToList();
            foreach (var item in FilterOfType)
            {
                Console.WriteLine($"Id : {item.ID} Name : {item.FirstName} {item.LastName} Salary : {item.Salary}");
            }
			var dataSource = new List<object>() { 1, 2, 3, 4, 5, 6, 7, "Vipul", "Bhavin", "Jil", "Abhi" };
			var OfTypeMethod = dataSource.OfType<string>().Where(x => x.Length > 4).ToList();
			
			foreach (var item in OfTypeMethod)
			{
				Console.WriteLine(item);
			}

            Console.WriteLine("--------------------------------------");

            // Where Method
            var whereMethod = Employee.GetEmployees().Where(emp => emp.Salary > 80000).ToList();
			foreach (var item in whereMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.FirstName} {item.LastName} Salary : {item.Salary}");
			}
            Console.WriteLine("-------------------------------");
            var OfTypeMethodLike = Employee.GetEmployees().Where(x => x.FirstName.EndsWith("l") && x.FirstName.StartsWith("V")).ToList();
			foreach (var item in OfTypeMethodLike)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.FirstName} {item.LastName} Salary : {item.Salary}");
			}
		}
	}
}