using CSharp_practical_8.models;

namespace CSharp_practical_8
{
    // Inheritance
    internal class ATM : ATMAction
    {
        // Method Overriding
        public override bool ChangePin(long acc)
        {
            Console.Write(" Enter New Pin : ");
            int newpin = Convert.ToInt32(Console.ReadLine());
            var holdername = DBContext.db.FirstOrDefault(e => e.AccountNumber == acc);
            if (holdername != null)
            {
                holdername.CardDetails!.Pin = newpin;
                return true;
            }
            return false;
        }
        // Method Overriding
        public override BankAccount GetAccountDetails(long bankAccount)
        {
            return DBContext.db.FirstOrDefault(e => e.AccountNumber == bankAccount)!;
        }
    }
}
