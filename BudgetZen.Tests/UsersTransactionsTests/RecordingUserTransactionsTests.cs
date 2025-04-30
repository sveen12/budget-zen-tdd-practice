using BudgetZen.Domain;
using BudgetZen.Domain.Exceptions;

namespace BudgetZen.Tests.UsersTransactionsTests
{
    public class RecordingUserTransactionsTests
    {
        private User user;
        private decimal amount;
        private string description;

        public RecordingUserTransactionsTests()
        {
            user = User.Create();
            Assert.Empty(user.Transactions);
            amount = 100m;
            description = "Transaction description";
        }

        [Fact]
        public void ShouldRecordIncomeTransaction()
        {
            // Arrange
            var transactionType = BudgetTransactionType.Income;

            // Act
            user.RecordTransaction(amount, description, transactionType);

            // Assert
            var transaction = Assert.Single(user.Transactions);
            Assert.Equal(user.Id, transaction.UserId);
            Assert.Equal(transactionType, transaction.Transaction.Type);
            Assert.Equal(amount, transaction.Transaction.Amount);
            Assert.Equal(description, transaction.Transaction.Description);
        }

        [Fact]
        public void ShouldRecordExpenseTransaction()
        {
            // Arrange
            var transactionType = BudgetTransactionType.Expense;

            // Act
            user.RecordTransaction(amount, description, transactionType);

            // Assert
            var transaction = Assert.Single(user.Transactions);
            Assert.Equal(user.Id, transaction.UserId);
            Assert.Equal(transactionType, transaction.Transaction.Type);
            Assert.Equal(amount, transaction.Transaction.Amount);
            Assert.Equal(description, transaction.Transaction.Description);
        }


        [Fact]
        public void ShouldThrowErrorWhenTransactionTypeDoesNotExists()
        {
            // Arrange
            var transactionType = (BudgetTransactionType)100;

            // Act
            var action = () => user.RecordTransaction(amount, description, transactionType);

            // Assert
            Assert.Throws<InvalidCreationException>(() => action());
        }

    }
}
