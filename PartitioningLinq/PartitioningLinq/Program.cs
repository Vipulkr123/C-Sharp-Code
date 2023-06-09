namespace PartitioningLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Student> students = new List<Student>()
						{
							new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
							new Student(){ID = 102, Name = "Preety", TotalMarks = 275 },
							new Student(){ID = 103, Name = "Vipul", TotalMarks = 250 },
							new Student(){ID = 104, Name = "Bhavin", TotalMarks = 305 },
							new Student(){ID = 105, Name = "Jil", TotalMarks = 350 },
							new Student(){ID = 106, Name = "Abhi", TotalMarks = 395 },
							new Student(){ID = 107, Name = "Jay", TotalMarks = 255 },
							new Student(){ID = 108, Name = "Abhay", TotalMarks = 300 }
						};

			// Take Method
			var TakeMethod = students.Take(5).ToList();
			foreach (var item in TakeMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.Name} Marks : {item.TotalMarks}");
			}

			Console.WriteLine("----------------------------------");

			// TakeWhile Method
			var TakeWhileMethod = students.TakeWhile(student => student.ID < 106).ToList();
			foreach (var item in TakeWhileMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.Name} Marks : {item.TotalMarks}");
			}

			Console.WriteLine("-----------------------------------");

			// Skip Method
			var SkipMethod = students.Skip(4).ToList();
			foreach (var item in SkipMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.Name} Marks : {item.TotalMarks}");
			}

			Console.WriteLine("--------------------------------");

			// SkipWhile Method 
			var SkipWhileMethod = students.SkipWhile(student => student.ID < 105).ToList();
			foreach (var item in SkipWhileMethod)
			{
				Console.WriteLine($"Id : {item.ID} Name : {item.Name} Marks : {item.TotalMarks}");
			}
		}
	}
}