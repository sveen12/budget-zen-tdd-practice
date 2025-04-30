using BudgetZen.Domain;

namespace BudgetZen.Tests.UsersTransactionsTests
{
    public class ReportingUserTransactionsTests
    {
        [Fact]
        public void ShouldGetExpenseFromTransactionList()
        {
            // Arrange
            var user = User.Create();
            Assert.Empty(user.Transactions);
            var amount = 100m;
            var description = "Transaction description";

            user.RecordTransaction(amount, description, BudgetTransactionType.Income);
            user.RecordTransaction(amount, description, BudgetTransactionType.Expense);
            user.RecordTransaction(amount, description, BudgetTransactionType.Expense);

            // Act
            TransactionHistoryRecord transactionHistoryRecord = user.GetExpense();

            // Assert
            Assert.Equal(BudgetTransactionType.Expense, transactionHistoryRecord.Transaction.Type);
        }
    }
}
