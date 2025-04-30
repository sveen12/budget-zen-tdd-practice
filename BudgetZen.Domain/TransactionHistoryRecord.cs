namespace BudgetZen.Domain
{
    public class TransactionHistoryRecord
    {
        private TransactionHistoryRecord()
        {

        }

        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public BudgetTransaction Transaction { get; private set; }

        public static TransactionHistoryRecord Create(BudgetTransaction transaction, User user)
        {
            return new TransactionHistoryRecord
            {
                Transaction = transaction,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
            };
        }
    }
}
