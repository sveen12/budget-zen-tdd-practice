using BudgetZen.Domain;

namespace BudgetZen.Tests.TransactionSpecs
{
    public class CreatingTransactionSpecs
    {
        [Fact]
        public void ShouldGenerateDifferentIdPerTransactions()
        {
            // Arrange
            var amount = TransactionAmount.Create(10m);
            var description = TransactionDescription.Create("Transaction description");

            // Act
            var firstTransaction = BudgetTransaction.CreateIncome(amount, description);
            var secondTransaction = BudgetTransaction.CreateIncome(amount, description);


            // Assert
            Assert.NotEqual(firstTransaction.Id, secondTransaction.Id);
        }

        [Fact]
        public void ShouldCreateExpenseTransaction()
        {
            //Arrange
            var amount = TransactionAmount.Create(100m);
            var description = TransactionDescription.Create("Transaction description");

            //Act
            var transaction = BudgetTransaction.CreateExpense(amount, description);

            //Assert
            Assert.Equal(amount.Value, transaction.Amount);
            Assert.Equal(description.Value, transaction.Description);
            Assert.Equal(BudgetTransactionType.Expense, transaction.Type);
            Assert.NotEqual(Guid.Empty, transaction.Id);
        }


        [Fact]
        public void ShouldCreateIncomeTransaction()
        {
            // Arrange
            var amount = TransactionAmount.Create(100m);
            var description = TransactionDescription.Create("Transaction description");

            // Act
            var transaction = BudgetTransaction.CreateIncome(amount, description);

            // Assert
            Assert.Equal(amount.Value, transaction.Amount);
            Assert.Equal(description.Value, transaction.Description);
            Assert.Equal(BudgetTransactionType.Income, transaction.Type);
            Assert.NotEqual(Guid.Empty, transaction.Id);
        }
    }
}
