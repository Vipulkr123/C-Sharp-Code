using Practical_4;
using System.Text.RegularExpressions;
namespace Practical_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int YourChoice = 0;
            Student student = new Student();
            do
            {
                Console.Write("Please Enter Student Name : ");
                student.Name = Console.ReadLine();
            } while (!Regex.IsMatch(student.Name, @"^[\p{L} \.\-]+$"));
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    Console.Write($"Enter {i + 1} Subject Marks : ");
                } while (!(decimal.TryParse(Console.ReadLine(), out student.Marks[i]) && student.Marks[i] <= 100 && student.Marks[i] >= 0));
            }

            do
            {
                Console.WriteLine("\nChoose 1,2,3,4");
                Console.WriteLine("1 - Aggregate");
                Console.WriteLine("2 - Min Mark");
                Console.WriteLine("3 - Maximum Mark");
                Console.WriteLine("4 - Grade");
                do
                {
                    Console.Write($"Please Enter Your Choice(1-4) : ");
                } while (!(int.TryParse(Console.ReadLine(), out YourChoice) && YourChoice <= 4 && YourChoice >= 1));
                Student.AverageMarks = student.CalculateAverageMarks();
                string Grade = student.CalculateGrade(Student.AverageMarks);
                string Result = YourChoice switch
                {
                    (int)Options.Aggregate => $"{student.Name} : {Student.AverageMarks}",
                    (int)Options.MinMark => $" {student.Marks.Min()}",
                    (int)Options.MaximumMark => $" {student.Marks.Max()}",
                    (int)Options.Grade => $" {Grade}",
                    _ => "Invalid Number",
                };
                Console.WriteLine(Result);
                Console.Write("Do you want to continue y/n : ");
            } while (Console.ReadKey().KeyChar.ToString().ToLower() == "y");
        }

    }
}