using System.Xml.XPath;

namespace SetOperatorLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
			List<Student> students = new List<Student>()
			{
				new Student() {Id =  1, Name = "Vipul"},
				new Student() {Id =  2, Name = "Bhavin"},
				new Student() {Id =  1, Name = "Vipul"},
				new Student() {Id =  3, Name = "Jil"},
				new Student() {Id =  4, Name = "Abhi"},
				new Student() {Id =  5, Name = "Jay"}
			};

			var qs = students.Distinct(new StudentComparer()).ToList();
            foreach (var item in qs)
            {
                Console.WriteLine(item.Name);
            }

			string[] files = { "abc.txt", "xyz.TXT", "pqr.py", "qwe.py", "vipul.Java", "jil.JAVA", "bhavin.java" };
			var vs = files.Select(file => Path.GetExtension(file).ToLower().TrimStart('.')).GroupBy(stud => stud, (e, grp) => new
			{
				Extension = e,
				NumberOfAppears = grp.Count(),
			}).ToList();

			foreach (var item in vs)
			{
				Console.WriteLine($"{item.Extension} => {item.NumberOfAppears} ");
            }

        }
	}
}