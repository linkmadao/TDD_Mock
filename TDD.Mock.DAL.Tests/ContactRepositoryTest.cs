using TDD.Mock.Domain;

namespace TDD.Mock.DAL.Tests
{
    public class ContactRepositoryTest
    {
        public IContactRepository _contactRepository;

        public ContactRepositoryTest()
        {
            _contactRepository = new ContactRepository();
        }

        [Fact(DisplayName = "Test Add Mock Fail")]
        public void ContactRepository_Add_ThrowsNotImplementedException()
        {
            // Arrange
            Contact contact = new();

            // Act & Assert
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Add(contact));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        [Fact(DisplayName = "Test Get Mock Fail")]
        public void ContactRepository_Get_ThrowsNotImplementedException()
        {
            // Arrange, Act & Assert
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Get(new Guid()));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        [Fact(DisplayName = "Test Update Mock Fail")]
        public void ContactRepository_Update_ThrowsNotImplementedException()
        {
            // Arrange, Act & Assert
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Update(new Guid(), "Jose"));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }

        [Fact(DisplayName = "Test Delete Mock Fail")]
        public void ContactRepository_Remove_ThrowsNotImplementedException()
        {
            var ex = Assert.Throws<NotImplementedException>(() => _contactRepository.Remove(new Guid()));
            Assert.Equal("The method or operation is not implemented.", ex.Message);
        }
    }
}
