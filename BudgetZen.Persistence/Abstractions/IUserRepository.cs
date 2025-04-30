using BudgetZen.Domain;

namespace BudgetZen.Persistence.Abstractions
{
    public interface IUserRepository
    {
        User? GetById(Guid id);
    }
}
