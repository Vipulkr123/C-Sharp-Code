namespace EqualityLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] countries1 = { "USA", "India", "UK" };
			string[] countries2 = { "USA", "India", "UK" };

			var result = countries1.SequenceEqual(countries2);

			Console.WriteLine("Are Equal = " + result);

			string[] countries = { "USA", "INDIA", "UK" };
			string[] countries3 = { "usa", "india", "uk" };

			var result2 = countries.SequenceEqual(countries3);

			Console.WriteLine("Are Equal = " + result2);

			string[] countries4 = { "USA", "INDIA", "UK" };
			string[] countries5 = { "usa", "india", "uk" };

			var result3 = countries4.SequenceEqual(countries5, StringComparer.OrdinalIgnoreCase);

			Console.WriteLine("Are Equal = " + result3);

			string[] countries6 = { "USA", "INDIA", "UK" };
			string[] countries7 = { "UK", "INDIA", "USA" };

			var result4 = countries6.SequenceEqual(countries7);

			Console.WriteLine("Are Equal = " + result4);


			string[] countries8 = { "USA", "INDIA", "UK" };
			string[] countries9 = { "UK", "INDIA", "USA" };

			var result5 = countries8.OrderBy(c => c).SequenceEqual(countries9.OrderBy(c => c));

			Console.WriteLine("Are Equal = " + result5);

			List<Employee> list1 = new List<Employee>()
				{
					new Employee { ID = 101, Name = "Mike"},
					new Employee { ID = 102, Name = "Susy"},
				};

			List<Employee> list2 = new List<Employee>()
				{
					new Employee { ID = 101, Name = "Mike"},
					new Employee { ID = 102, Name = "Susy"},
				};

			var result6 = list1.SequenceEqual(list2);

			Console.WriteLine("Are Equal = " + result6);

		}
	}
	public class Employee
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}
}