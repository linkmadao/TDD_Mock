using TDD.Mock.Domain;

namespace TDD.Mock.DAL
{
    public interface IUsersRepository
    {
        Task Create(User user);
    }
}
