
using System.Linq;
using System;
using System.Collections.Generic;
namespace ConcatLinq
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> sequence1 = new List<int> { 1, 2, 3, 4 };
			List<int> sequence2 = new List<int> { 2, 4, 6, 8 };

			//Method Syntax
			var MS = sequence1.Concat(sequence2);

			//Query Syntax
			var QS = (from num in sequence1
					  select num)
					  .Concat(sequence2).ToList();

			foreach (var item in MS)
			{
				Console.Write(item + " ");
			}

			Console.ReadLine();
		}
	}
}