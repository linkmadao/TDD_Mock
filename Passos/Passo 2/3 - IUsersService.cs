using TDD.Mock.Domain;

namespace TDD.Mock.Services
{
    public interface IUsersService
    {
        Task Create(User user);
    }
}