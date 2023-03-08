using FluentAssertions;
using Moq;
using System.Xml.Linq;
using TDD.Mock.DAL;
using TDD.Mock.Domain;
using TDD.Mock.Services;

namespace TDD.Mock.Tests
{
    public class ContactsServiceTest
    {
        private readonly Mock<IContactRepository> _contactRepository;
        private readonly IContactsService _contactsService;

        public ContactsServiceTest()
        {
            _contactRepository = new Mock<IContactRepository>();
            _contactsService = new ContactsService(_contactRepository.Object);
        }

        [Fact(DisplayName = "Test Add Mock Equal")]
        public void TestAddEqual()
        {
            // Arrange
            _contactRepository.Setup(t => t.Add(It.IsAny<Contact>())).Returns(new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"));

            // Act
            Guid result = _contactsService.Add("Jose", "01123456789");
            
            // Assert
            result.Should().Be(Guid.Parse("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"));
        }

        [Fact(DisplayName = "Test Add Mock NotEqual")]
        public void TestAddNotEqual()
        {
            // Arrange
            _contactRepository.Setup(t => t.Add(It.IsAny<Contact>())).Returns(new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD582"));

            // Act
            Guid result = _contactsService.Add("Jose", "01123456789");

            result.Should().NotBe(Guid.Parse("88C3E7C6-B768-4B74-AFFD-4800E9FBD582"));
        }


        [Fact(DisplayName = "Test Add Mock Fail")]
        public void TestAddFail()
        {
            try
            {
                // Arrange
                _contactRepository.Setup(t => t.Add(It.IsAny<Contact>())).Throws(new IOException());

                // Act
                Guid result = _contactsService.Add("Jose", "01123456789");

                // Assert
                Assert.Fail("Falha ao cair no exception.");
            }
            catch (Exception ex)
            {
                Assert.Equal("I/O error occurred.", ex.Message);
            }
        }


        [Theory(DisplayName = "Test Update Contact Equal")]
        [InlineData("88C3E7C6-B768-4B74-AFFD-4800E9FBD581", "Maria", true)]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A", "Abreu", true)]
        public void TestUpdateEqual(string id, string name, bool expectedResult)
        {
            // Arrange
            _contactRepository.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<string>())).Returns(true);

            // Act
            bool result = _contactsService.Update(Guid.Parse(id), name);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory(DisplayName = "Test Update Contact NotEqual")]
        [InlineData("88C3E7C6-B768-4B74-AFFD-4800E9FBD581", "Maria", false)]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A", "Abreu", false)]
        public void TestUpdateNotEqual(string id, string name, bool expectedResult)
        {
            // Arrange
            _contactRepository.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<string>())).Returns(false);

            // Act
            bool result = _contactsService.Update(Guid.Parse(id), name);

            // Assert
            Assert.NotEqual(expectedResult, result);
        }

        [Theory(DisplayName = "Test Update Contact NotExecuted")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A", "Abreu", true)]
        public void TestUpdateFail(string id, string name, bool expectedResult)
        {
            // Arrange
            Guid newId = Guid.Parse(id);

            // Act
            bool result = _contactsService.Update(newId, name);

            // Assert
            Assert.NotEqual(expectedResult, result);
        }

        [Theory(DisplayName = "Test Get Contact Ok")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A")]
        public void TestGetOk(string id)
        {
            // Arrange
            Guid newId = Guid.Parse(id);
            var match = new Contact()
            {
                Id = newId,
                Name = "Jose",
                Telephone = new List<string>()
                    {
                        "012345678901"
                    }
            };

            // Act
            var result = _contactsService.Get(newId);

            // Assert
            result.Should().BeEquivalentTo(match);
        }

    }
}