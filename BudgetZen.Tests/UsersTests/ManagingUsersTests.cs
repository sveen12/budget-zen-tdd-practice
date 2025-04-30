using BudgetZen.Domain;

namespace BudgetZen.Tests.UsersTests
{
    public class ManagingUsersTests
    {
        public void ShouldCreateUser()
        {
            var user = User.Create();
            Assert.Equal(Guid.Empty, user.Id);
            Assert.Empty(user.Transactions);
        }
    }
}
