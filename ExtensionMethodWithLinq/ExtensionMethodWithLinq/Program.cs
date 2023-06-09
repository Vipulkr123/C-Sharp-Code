using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodWithLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string Name = "vipul Kumar";
			string Result = Name.ChangeFirstLetterCase();
			Console.WriteLine(Result);

			List<int> Number = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };
			IEnumerable<int> EvenNumbers = Number.Where(n => n % 2 == 0);

            foreach (var EvenNumber in EvenNumbers)
            {
                Console.Write(EvenNumber + " ");
            }
            Console.ReadKey();
		}
	}
}
