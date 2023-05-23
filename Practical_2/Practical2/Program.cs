namespace Practical2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("\n********* Customer Bank Detail ***********\n");
            CustomerAccount ca = new(123456,"Vipul Upadhyay");
            ca.BankName = "SBI";
            ca.printInfo();
            Console.WriteLine("\n******************************************\n");
            CustomerAccount custAcc = new(790369, "Bhavin Karelia");
            custAcc.BankName = "Bank of India";
            custAcc.printInfo();
            Console.WriteLine("\n******************************************\n");
            CustomerAccount custAccount = new(907345, "Jil Patel");
            custAccount.BankName = "Bank of Baroda";
            custAccount.printInfo();
        }

    }
}