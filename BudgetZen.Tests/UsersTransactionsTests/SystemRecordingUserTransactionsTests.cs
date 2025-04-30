using BudgetZen.Application.Exceptions;
using BudgetZen.Application.Features.Transactions.RecordTransactions;
using BudgetZen.Domain;
using BudgetZen.Persistence.Abstractions;
using BudgetZen.Tests.InMemory;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace BudgetZen.Tests.UsersTransactionsTests
{
    public class SystemRecordingUserTransactionsTests
    {
        private Guid userId;
        private IUserRepository userRepository;
        private RecordTransactionHandler handler;
        private decimal amount;
        private string description;

        public SystemRecordingUserTransactionsTests()
        {
            userId = new Guid("5D9C5166-5312-4F82-9D8D-FDF545A68464");
            userRepository = Substitute.For<IUserRepository>();
            handler = new RecordTransactionHandler(userRepository);
            amount = 100m;
            description = "Transaction description";
        }


        [Fact]
        public void ShouldThrowExceptionWhenUserDoesNotExists()
        {
            // Arrange
            userRepository.GetById(userId).ReturnsNull();
            BudgetTransactionType transactionType = BudgetTransactionType.Income;

            // Act
            var action = () => handler.Handle(userId, amount, description, transactionType);

            // Assert
            Assert.Throws<NotFoundException>(() => action());
        }

        [Fact]
        public void ShouldRecordTransaction()
        {
            // Arrange
            BudgetTransactionType transactionType = BudgetTransactionType.Income;
            var userRepository = new InMemoryUsers();
            Assert.Equal([], userRepository.user.Transactions);
            var handler = new RecordTransactionHandler(userRepository);

            // Act
            var result = handler.Handle(userRepository.user.Id, amount, description, transactionType);

            // Assert
            Assert.Single(userRepository.user.Transactions);
        }

        [Fact]
        public void ShouldReturnCorrectTransactionId()
        {
            // Arrange
            BudgetTransactionType transactionType = BudgetTransactionType.Income;
            var userRepository = new InMemoryUsers();
            var handler = new RecordTransactionHandler(userRepository);

            // Act
            var result = handler.Handle(userRepository.user.Id, amount, description, transactionType);

            // Assert
            var createdTransaction = userRepository.user.Transactions.Single().Transaction;
            Guid resultTransactionId = result.Id;
            Assert.Equal(createdTransaction.Id, resultTransactionId);
        }
    }
}
