using System;
using System.Linq;
namespace AggregateFunLinq
{
	class Program
	{
		static void Main()
		{
			int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			int smallestNumber = Numbers.Min();
			int smallestEvenNumber = Numbers.Where(n => n % 2 == 0).Min();

			int largestNumber = Numbers.Max();
			int largestEvenNumber = Numbers.Where(n => n % 2 == 0).Max();

			int sumOfAllNumbers = Numbers.Sum();
			int sumOfAllEvenNumbers = Numbers.Where(n => n % 2 == 0).Sum();

			int countOfAllNumbers = Numbers.Count();
			int countOfAllEvenNumbers = Numbers.Where(n => n % 2 == 0).Count();

			double averageOfAllNumbers = Numbers.Average();
			double averageOfAllEvenNumbers = Numbers.Where(n => n % 2 == 0).Average();

			Console.WriteLine("Smallest Number = " + smallestNumber);
			Console.WriteLine("Smallest Even Number = " + smallestEvenNumber);

			Console.WriteLine("Largest Number = " + largestNumber);
			Console.WriteLine("Largest Even Number = " + largestEvenNumber);

			Console.WriteLine("Sum of All Numbers = " + sumOfAllNumbers);
			Console.WriteLine("Sum of All Even Numbers = " + sumOfAllEvenNumbers);

			Console.WriteLine("Count of All Numbers = " + countOfAllNumbers);
			Console.WriteLine("Count of All Even Numbers = " + countOfAllEvenNumbers);

			Console.WriteLine("Average of All Numbers = " + averageOfAllNumbers);
			Console.WriteLine("Average of All Even Numbers = " + averageOfAllEvenNumbers);

			var QuerySyntax = (from number in Numbers
								 where number > 5
								 orderby number descending
								 select number).Take(3);

			var Num = Numbers.Where(e => e > 5).OrderByDescending(e => e).Take(3);
            foreach (var item in Num)
            {
                Console.Write(item + " ");
            }
        }
	}
}