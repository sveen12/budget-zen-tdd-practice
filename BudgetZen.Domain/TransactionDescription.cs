using BudgetZen.Domain.Exceptions;

namespace BudgetZen.Domain
{
    public class TransactionDescription
    {
        public string Value { get; private set; }

        public static TransactionDescription Create(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new InvalidCreationException();
            }

            return new TransactionDescription { Value = description };
        }
    }
}
