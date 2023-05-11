namespace Practical_6
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            processBusinessLogic.ProcessCompleted += pbl_ProcessCompleted;
            processBusinessLogic.StartProcess();
        }

        //! Event Handler
        public static void pbl_ProcessCompleted()
        {
            Console.WriteLine("Method Invoked");
        }
    }
}