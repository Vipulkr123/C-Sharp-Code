namespace QuantifierLinq
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


			// All Method
			var AllMethod = students.All(student => student.TotalMarks > 240);
			Console.WriteLine(AllMethod);

			// Any Method
			var AnyMethod = students.Any(student => student.TotalMarks > 350 && student.Name == "Abhi");
            Console.WriteLine(AnyMethod);

			// Contains
			List<string> names = new List<string>() { "Vipul", "Bhavin", "Jil", "Abhi", "Jay" }; 
			var ContainsMethod = names.Contains("Vipul" );
			Console.WriteLine(ContainsMethod);
        }
	}
}