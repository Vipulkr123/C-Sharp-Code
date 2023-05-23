using CSharp_practical_8.models;

namespace CSharp_practical_8
{
    // Interface
    internal interface IBankAction
    {
        public bool CreateAccount(BankAccount bankAccount);
        public bool UpdateAccountDetails(long bankAccount);
        public bool DeleteAccount(long bankAccount);
        public BankAccount GetAccountDetails(long bankAccount);
        public bool Login(long accnum, string accesskey);
        public bool RequestATMCard(long accnum);

    }
}
