
namespace BudgetZen.Domain
{
    public class BudgetTransaction
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public BudgetTransactionType Type { get; private set; }
        public Guid Id { get; private set; }

        private BudgetTransaction()
        {
        }

        private static BudgetTransaction Create(TransactionAmount amount, TransactionDescription description, BudgetTransactionType type)
        {
            return new BudgetTransaction
            {
                Id = Guid.CreateVersion7(),
                Amount = amount.Value,
                Description = description.Value,
                Type = type
            };
        }

        public static BudgetTransaction CreateIncome(TransactionAmount amount, TransactionDescription description)
        {
            return Create(amount, description, BudgetTransactionType.Income);
        }

        public static BudgetTransaction CreateExpense(TransactionAmount amount, TransactionDescription description)
        {
            return Create(amount, description, BudgetTransactionType.Expense);
        }
    }
}
