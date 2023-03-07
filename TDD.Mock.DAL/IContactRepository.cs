using TDD.Mock.Domain;

namespace TDD.Mock.DAL
{
    public interface IContactRepository
    {
        Guid Add(Contact contact);
        Contact Get(Guid id);
        bool Update(Guid id, string name);
        bool Remove(Guid id);
    }
}