using BudgetZen.Domain;

namespace BudgetZen.Tests.TransactionSpecs
{
    public class CreatingTransactionHistorySpecs
    {
        [Fact]
        public void ShouldCreateTransactionHistoryRecord()
        {
            // Arrange
            var user = User.Create();
            var budgetTransaction = BudgetTransaction.CreateIncome(TransactionAmount.Create(100m), TransactionDescription.Create("Transaction description"));

            // Act
            var before = DateTime.UtcNow;
            var transactionHistoryRecord = TransactionHistoryRecord.Create(budgetTransaction, user);
            var after = DateTime.UtcNow;

            // Assert
            Assert.Equal(budgetTransaction, transactionHistoryRecord.Transaction);
            Assert.Equal(user.Id, transactionHistoryRecord.UserId);
            Assert.True(before < transactionHistoryRecord.CreatedAt);
            Assert.True(after > transactionHistoryRecord.CreatedAt);
        }
    }
}
