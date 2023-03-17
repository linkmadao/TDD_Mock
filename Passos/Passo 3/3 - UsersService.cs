using TDD.Mock.DAL;
using TDD.Mock.Domain;

namespace TDD.Mock.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task Create(User user)
        {
            if (user.CPF.Length < 11)
            {
                throw new ArgumentException("Invalid CPF");
            }

            await _usersRepository.Create(user);
        }
    }
}