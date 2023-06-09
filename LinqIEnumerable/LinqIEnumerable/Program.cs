
namespace LinqIEnumerable
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Student> studentList = new List<Student>()
			{
				new Student(){ID = 1, Name = "Vipul", Gender = "Male"},
				new Student(){ID = 2, Name = "Bhavin", Gender = "Male"},
				new Student(){ID = 3, Name = "Jil", Gender = "Male"},
				new Student(){ID = 4, Name = "Abhi", Gender = "Male"},
				new Student(){ID = 5, Name = "Abc", Gender = "Female"}
			};

			//Linq Query to Fetch all students with Gender Male
			IEnumerable<Student> QuerySyntax = from std in studentList
											   where std.Gender == "Male"
											   select std;
			//Iterate through the collection
			foreach (var student in QuerySyntax)
			{
				Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
			}

			IQueryable<Student> studentsLt = studentList.Where(std => std.Gender == "Male").AsQueryable();
			foreach (var student in studentsLt)
			{
				Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
			}

			List<int> lists = new List<int>() { 4, 3, 5 ,2 ,7, 9,1, 6, 10, 8};
			var AddOne = lists.Select(n => n + 1);
			var odd = lists.Select((s, i) => new { num = s, index = i }).Where(S => S.num % 2 != 0 && S.num > 5);

			var odd1 = (from item in lists.Select((s, i) => new { s, i }) where item.s % 2 != 0 && item.s > 5 select new { index = item.i, num = item.s }).ToList();

			var SumOfOdd = lists.Where(e => e % 2 != 0).Sum();
			var SumOfEven = lists.Where(e => e % 2 == 0).Sum();
			var test = lists.Sum(e => e % 2);
			Console.WriteLine($"Sum of Odd : {SumOfOdd}");
			Console.WriteLine($"Sum of Even : {SumOfEven}");
			Console.WriteLine(test);
            foreach (var item in odd1)
			{
				Console.WriteLine($"IndexPosition :{item}");
			}
			foreach (var item in AddOne)
			{
				Console.WriteLine($"IndexPosition :{item}");
			}
			Console.ReadKey();
		}
	}

	public class Student
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
	}
}