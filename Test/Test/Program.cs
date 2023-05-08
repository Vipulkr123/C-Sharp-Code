using System;
namespace Test
{
    internal class Program
    {
        static string backValue = string.Empty;
        static double value, Input_1 = 0, Input_2 = 0;
        static ConsoleKeyInfo inputKey;

        static void Main(string[] args)
        {
            Console.Title = "Calculator";
            Console.Write("Enter First number : ");
            Program.ValidateNumber();
            if (double.TryParse(backValue, out value))
                Input_1 = value;
            backValue = string.Empty;
            value = 0;
            Console.WriteLine();
            Console.Write("Enter Second number : ");
            Program.ValidateNumber();
            if (double.TryParse(backValue, out value))
                Input_2 = value;
            Console.WriteLine();

            if (Input_2 != 0)
            {
                Console.WriteLine($"The sum of {Input_1} and {Input_2} is {Math.Round((Input_1 + Input_2), 4)}");
                Console.WriteLine($"The subtraction  of {Input_1} and {Input_2} is {Math.Round((Input_1 - Input_2), 4)}");
                Console.WriteLine($"The multiplication of {Input_1} and {Input_2} is {Math.Round((Input_1 * Input_2), 4)}");
                Console.WriteLine($"The division  of {Input_1} and {Input_2} is {Math.Round((Input_1 / Input_2), 4)}");
            }
            else
            {
                Console.WriteLine($"The {Input_1} can't Divide by 0");
            }
        }

        public static void ValidateNumber()
        {
            do
            {
                inputKey = Console.ReadKey(true);

                if (char.IsDigit(inputKey.KeyChar))
                {
                    if (inputKey.KeyChar == '0')
                    {
                        if (!backValue.StartsWith("0") || backValue.Contains('.'))
                            Write();
                    }

                    else
                        Write();
                }

                if (inputKey.KeyChar == '-' && backValue.Length == 0 ||
                    inputKey.KeyChar == '.' && !backValue.Contains(inputKey.KeyChar) &&
                    backValue.Length > 0)
                        Write();

                if (inputKey.Key == ConsoleKey.Backspace && backValue.Length > 0)
                {
                    backValue = backValue.Substring(0, backValue.Length - 1);
                    Console.Write("\b \b");
                }
            } while (inputKey.Key != ConsoleKey.Enter);
        }

        static void Write()
        {
            backValue += inputKey.KeyChar;
            Console.Write(inputKey.KeyChar);
        }
    }
}