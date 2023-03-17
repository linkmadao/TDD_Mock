using TDD.Mock.Domain;

namespace TDD.Mock.Services
{
    public class UsersService : IUsersService
    {
        public UsersService()
        {
        }

        public async Task Create(User user)
        {
            throw new ArgumentException("Invalid CPF");
        }
    }
}