using TDD.Mock.Domain;

namespace TDD.Mock.Services
{
    public interface IContactsService
    {
        Guid Add(string name, string telephone);
        Contact Get(Guid id);
        bool Update(Guid id, string name);
        bool Remove(Guid id);
    }
}
