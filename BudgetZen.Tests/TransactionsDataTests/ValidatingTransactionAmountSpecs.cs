using BudgetZen.Domain;
using BudgetZen.Domain.Exceptions;

namespace BudgetZen.Tests.TransactionsDataSpecs
{
    public class ValidatingTransactionAmountSpecs
    {
        [Fact]
        public void AssignsCorrectValueToTransactionAmount()
        {
            //Arrange
            var amount = 100m;

            //Act
            var transactionAmount = TransactionAmount.Create(amount);

            //Assert
            Assert.Equal(amount, transactionAmount.Value);
        }

        [Fact]
        public void ThrowsException_WhenAmountIsZero()
        {
            //Arrange
            decimal amount = 0.00m;

            //Asert
            Action action = () => { TransactionAmount.Create(amount); };

            //Act
            Assert.Throws<InvalidCreationException>(action);
        }

        [Fact]
        public void ThrowsException_WhenAmountIsNegative()
        {
            //Arrange
            decimal amount = -100m;

            //Asert
            Action action = () => { TransactionAmount.Create(amount); };

            //Act
            Assert.Throws<InvalidCreationException>(action);
        }
    }
}
