namespace gROUPINGlINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> list = new List<string>() { "Vipul", "Vinay", "Bhavin", "Vishvas", "Bunty", "Jil", "Jay", "Jenish", "Abhi" };

			var qs = from ls in list
					 group ls by ls[0] into lsGroup
					 select new
					 {
						 Key = lsGroup.Key,
						 Name  = lsGroup.OrderBy(x => x).ToList()
					 };

            foreach (var item in qs)
            {
                Console.WriteLine($"Key {item.Key}");
				foreach (var item1 in item.Name)
				{
					Console.Write($" {item1}");
				}
                Console.WriteLine();
            }

            Console.WriteLine("======================");

            var le = list.GroupBy(ls => ls[0]).ToList();

			foreach (var item in le)
			{
				Console.WriteLine($"Key {item.Key}");
				foreach (var item1 in item)
				{
					Console.Write($" {item1}");
				}
				Console.WriteLine();
			}

			Console.WriteLine("======================");

			var ToLookupMethod = list.ToLookup(ls => ls[0]).ToList();

			foreach (var item in ToLookupMethod)
			{
				Console.WriteLine($"Key {item.Key}");
				foreach (var item1 in item)
				{
					Console.Write($" {item1}");
				}
				Console.WriteLine();
			}
		}
	}
}