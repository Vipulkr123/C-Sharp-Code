namespace Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j || i == n - 1|| j == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}