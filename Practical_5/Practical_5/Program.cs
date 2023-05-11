namespace Practical_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5};

            for(int i = 0; i < 5; i++)
            {
                try
                {
                    Console.WriteLine(arr[i]);
                }
                catch (IndexOutOfRangeException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("This is finally block");
                }
            }
        }
    }
}