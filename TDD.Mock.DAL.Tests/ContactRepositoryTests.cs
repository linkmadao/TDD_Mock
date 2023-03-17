using TDD.Mock.Domain;

namespace TDD.Mock.DAL.Tests
{
    public class ContactRepositoryTests
    {
        public IContactRepository _contactRepository;

        public ContactRepositoryTests()
        {
            _contactRepository = new ContactRepository();
        }

        [Fact(DisplayName = "Add Mock Fail")]
        [Trait("Category", "Contact Repository Tests")]
        public void ContactRepository_Add_ThrowsNotImplementedException()
        {
            // Arrange
            Contact contact = new();

            // Act & Assert
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Add(contact));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        [Fact(DisplayName = "Get Mock Fail")]
        [Trait("Category", "Contact Repository Tests")]
        public void ContactRepository_Get_ThrowsNotImplementedException()
        {
            // Arrange, Act & Assert
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Get(new Guid()));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        [Fact(DisplayName = "Update Mock Fail")]
        [Trait("Category", "Contact Repository Tests")]
        public void ContactRepository_Update_ThrowsNotImplementedException()
        {
            // Arrange, Act & Assert
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Update(new Guid(), "Jose"));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        [Fact(DisplayName = "Delete Mock Fail")]
        [Trait("Category", "Contact Repository Tests")]
        public void ContactRepository_Remove_ThrowsNotImplementedException()
        {
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Remove(new Guid()));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }
    }
}
