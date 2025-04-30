
using BudgetZen.Domain.Exceptions;

namespace BudgetZen.Domain
{
    public class User
    {
        private List<TransactionHistoryRecord> transactions;
        public Guid Id { get; private set; }
        public IReadOnlyCollection<TransactionHistoryRecord> Transactions => transactions;

        public static User Create()
        {
            return new User { Id = Guid.NewGuid(), transactions = [] };
        }

        public TransactionHistoryRecord GetExpense()
        {
            return transactions.First(x => x.Transaction.Type is BudgetTransactionType.Expense);
        }

        public Guid RecordTransaction(decimal amount, string description, BudgetTransactionType transactionType)
        {

            var transaction = transactionType switch
            {
                BudgetTransactionType.Income => BudgetTransaction.CreateIncome(TransactionAmount.Create(amount), TransactionDescription.Create(description)),
                BudgetTransactionType.Expense => BudgetTransaction.CreateExpense(TransactionAmount.Create(amount), TransactionDescription.Create(description)),
                _ => throw new InvalidCreationException()
            };

            var transactionHistoryRecord = TransactionHistoryRecord.Create(transaction, this);
            transactions.Add(transactionHistoryRecord);
            return transaction.Id;
        }
    }
}
