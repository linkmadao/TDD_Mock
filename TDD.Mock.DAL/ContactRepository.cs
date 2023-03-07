using TDD.Mock.Domain;

namespace TDD.Mock.DAL
{
    public class ContactRepository : IContactRepository
    {
        public Guid Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, string name)
        {
            throw new NotImplementedException();
        }
    }
}