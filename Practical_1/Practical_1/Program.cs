using System;
namespace Practical_1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string s = Console.ReadKey();
            if (ConsoleKey.D0 >= Convert.ToInt32(s) )
            {
                Console.WriteLine("exit");
            }

        }
    }
}