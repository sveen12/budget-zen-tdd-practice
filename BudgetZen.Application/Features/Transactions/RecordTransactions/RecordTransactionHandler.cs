using BudgetZen.Application.Exceptions;
using BudgetZen.Domain;
using BudgetZen.Persistence.Abstractions;

namespace BudgetZen.Application.Features.Transactions.RecordTransactions
{
    public class RecordTransactionHandler(IUserRepository userRepository)
    {
        public RecordTransactionResult Handle(Guid userId, decimal amount, string description, BudgetTransactionType transactionType)
        {
            var user = userRepository.GetById(userId);
            if (user is null)
            {
                throw new NotFoundException();
            }

            var transactionId = user.RecordTransaction(amount, description, transactionType);

            return new RecordTransactionResult(transactionId);
        }
    }
}
