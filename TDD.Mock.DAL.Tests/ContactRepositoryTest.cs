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
        public void TestAddFail()
        {
            try
            {
                // Arrange
                Contact contact = new();

                // Act
                _contactRepository.Add(contact);

                // Assert
                Assert.Fail("Falha ao cair no exception.");
            }
            catch (Exception ex)
            {
                Assert.Equal("The method or operation is not implemented.", ex.Message);
            }
        }

        [Fact(DisplayName = "Test Get Mock Fail")]
        public void TestGetFail()
        {
            try
            {
                // Act
                _contactRepository.Get(new Guid());

                // Assert
                Assert.Fail("Falha ao cair no exception.");
            }
            catch (Exception ex)
            {
                Assert.Equal("The method or operation is not implemented.", ex.Message);
            }
        }

        [Fact(DisplayName = "Test Update Mock Fail")]
        public void TestUpdateFail()
        {
            try
            {
                // Act
                _contactRepository.Update(new Guid(), "Jose");

                // Assert
                Assert.Fail("Falha ao cair no exception.");
            }
            catch (Exception ex)
            {
                Assert.Equal("The method or operation is not implemented.", ex.Message);
            }
        }

        [Fact(DisplayName = "Test Delete Mock Fail")]
        public void TestDeleteFail()
        {
            try
            {
                // Act
                _contactRepository.Remove(new Guid());

                // Assert
                Assert.Fail("Falha ao cair no exception.");
            }
            catch (Exception ex)
            {
                Assert.Equal("The method or operation is not implemented.", ex.Message);
            }
        }
    }
}
