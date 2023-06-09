
using System;
namespace AggFunLinq
{
	class Program
	{
		static void Main()
		{
			string[] countries = { "India", "US", "UK", "Canada", "Australia" };
			int[] arr = {1, 2, 3, 4, 5 , 6, 7, 8 , 9, 10};
			// General Method
			string result = string.Empty;
            foreach (var item in countries)
            {
				result = result + item + ",";
            }
            Console.WriteLine(result);

			
			int lastIndex = result.LastIndexOf(",");
			result = result.Remove(lastIndex);

			// Using Linq 
			var Query = countries.Aggregate((a,b) => a + "," + b);
            Console.WriteLine(Query);

            // For Slice 
            var Test = countries.AsSpan<string>();
			var test2 = Test.Slice(2,1);

            foreach (var item in test2)
            {
                Console.WriteLine(item);
            }

			List<Int64> ints = new List<Int64>() { 1, 2, 3, 4, 5, 6, 7, 8 , 9 ,10 };
			var test = ints.Aggregate((x, y) => { return Convert.ToInt64(x.ToString() + y.ToString()); });
			Console.WriteLine(test);

			List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var result2 = ints.ConvertAll(x => x.ToString()).Aggregate((x, y) => x + y);
			Console.WriteLine(result2);
		}
	}
}