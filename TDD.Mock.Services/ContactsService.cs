using TDD.Mock.DAL;
using TDD.Mock.Domain;

namespace TDD.Mock.Services
{
    public class ContactsService : IContactsService
    {
        private List<Contact> _contacts = new();
        private readonly IContactRepository _contactRepository;

        public ContactsService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Guid Add(string name, string telephone)
        {
            Contact contact = new()
            {
                Id = Guid.Parse("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"),
                Name = name,
                Telephone = new List<string>() { telephone }
            };

            _contactRepository.Add(contact);
            return contact.Id;
        }

        public Contact Get(Guid id) 
        { 
            _contacts = new List<Contact>()
            {
                new Contact()
                {
                    Id = new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"),
                    Name = "Jose",
                    Telephone = new List<string>()
                    {
                        "012345678901"
                    }
                }
            };

            return _contacts.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Guid id, string name)
        {
            _contacts = new List<Contact>()
            {
                new Contact()
                {
                    Id = new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"),
                    Name = "Jose",
                    Telephone = new List<string>()
                    {
                        "012345678901"
                    }
                }
            };

            Contact contact = _contacts.FirstOrDefault(t => t.Id == id);
            return contact != null;
        }

        public bool Remove(Guid id)
        {
             _contacts = new List<Contact>()
            {
                new Contact()
                {
                    Id = new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"),
                    Name = "Jose",
                    Telephone = new List<string>()
                    {
                        "012345678901"
                    }
                }
            };

            Contact contact = _contacts.FirstOrDefault(t => t.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                return true;    
            }

            return false;
        }
    }
}