using BudgetZen.Domain;
using BudgetZen.Persistence.Abstractions;

namespace BudgetZen.Tests.InMemory
{
    internal class InMemoryUsers : IUserRepository
    {
        public User user;

        public InMemoryUsers()
        {
            user = User.Create();
        }

        public User? GetById(Guid id)
        {
            return id == user.Id ? user : null;
        }
    }
}
