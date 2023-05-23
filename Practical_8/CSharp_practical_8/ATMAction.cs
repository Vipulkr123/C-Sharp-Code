using CSharp_practical_8.models;


namespace CSharp_practical_8
{
    // Abstraction 
    internal abstract class ATMAction
    { 
        public abstract bool ChangePin(long acc);
        public abstract BankAccount GetAccountDetails(long bankAccount);

    }
}
