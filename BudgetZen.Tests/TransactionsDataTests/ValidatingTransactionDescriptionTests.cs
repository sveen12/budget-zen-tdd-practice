using BudgetZen.Domain;
using BudgetZen.Domain.Exceptions;

namespace BudgetZen.Tests.TransactionsDataSpecs
{
    public class ValidatingTransactionDescriptionSpecs
    {
        [Fact]
        public void ShouldCreateWhenDescriptionIsGiven()
        {
            // Arrange
            var description = "This is a description";

            // Act
            var transactionDescription = TransactionDescription.Create(description);

            // Assert
            Assert.Equal(description, transactionDescription.Value);
        }

        [Fact]
        public void ShouldThrowExceptionWhenEmptyIsGiven()
        {
            // Arrange
            var description = string.Empty;

            // Act
            Action action = () => { TransactionDescription.Create(description); };

            // Assert
            Assert.Throws<InvalidCreationException>(action);
        }

        [Fact]
        public void ShouldThrowExceptionWhenNullIsGiven()
        {
            // Arrange
            string description = null!;

            // Act
            Action action = () => { TransactionDescription.Create(description); };

            // Assert
            Assert.Throws<InvalidCreationException>(action);
        }
    }
}
