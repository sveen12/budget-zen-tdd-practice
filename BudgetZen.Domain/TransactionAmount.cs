using BudgetZen.Domain.Exceptions;

namespace BudgetZen.Domain
{
    public class TransactionAmount
    {
        public decimal Value { get; private set; }
        public static TransactionAmount Create(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidCreationException();
            }

            return new TransactionAmount { Value = amount };
        }
    }
}
