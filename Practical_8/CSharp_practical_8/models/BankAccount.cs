namespace CSharp_practical_8.models
{
    public class BankAccount
    {
        // Encapsulation
        public long AccountNumber { get; init; }
        public string? AccessKey { get; init; }
        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public long CustomerPhoneNumber { get; set; }
        public double? BankBalance { get; set; } = 0;
        public CardDetail? CardDetails { get; set; }
        public string? BranchName { get; set; }
        public bool HasATMCard { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public ACC_TYPE AccountType { get; set; }

        public enum ACC_TYPE
        {
            SAVING = 1,
            FIXED_DEPOSITE
        }
    }
}
