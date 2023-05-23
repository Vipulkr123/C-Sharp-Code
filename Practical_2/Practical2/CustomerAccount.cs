namespace Practical2
{
    internal class CustomerAccount
    {
        public string BankName = default!;
        private readonly long _customerAccountNo;
        private readonly string _customerName;
        public CustomerAccount(long accountNo, string customerName)
        {
            this._customerAccountNo = accountNo;
            this._customerName = customerName;
        }
        /// <summary>
        /// It Print all the Bank details of customer account
        /// </summary>
        public void printInfo()
        {
            Console.WriteLine($"Bank : {BankName} \nCustomer Name : {_customerName} \nAccount No : {_customerAccountNo}");
        }
    }
}
