using FluentAssertions;
using Moq;
using System.Xml.Linq;
using TDD.Mock.DAL;
using TDD.Mock.Domain;
using TDD.Mock.Services;

namespace TDD.Mock.Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactRepository> _contactRepository;
        private readonly IContactsService _contactsService;

        public ContactServiceTests()
        {
            _contactRepository = new Mock<IContactRepository>();
            _contactsService = new ContactsService(_contactRepository.Object);
        }

        [Fact(DisplayName = "Add Mock Equal")]
        [Trait("Category", "Contact Service Tests")]
        public void ContactService_Add_Equal()
        {
            // Arrange
            _contactRepository.Setup(t => t.Add(It.IsAny<Contact>())).Returns(new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"));

            // Act
            Guid result = _contactsService.Add("Jose", "01123456789");

            // Assert
            result.Should().Be(Guid.Parse("88C3E7C6-B768-4B74-AFFD-4800E9FBD581"));
        }

        [Fact(DisplayName = "Add Mock NotEqual")]
        [Trait("Category", "Contact Service Tests")]
        public void ContactService_Add_NotEqual()
        {
            // Arrange
            _contactRepository.Setup(t => t.Add(It.IsAny<Contact>())).Returns(new Guid("88C3E7C6-B768-4B74-AFFD-4800E9FBD582"));

            // Act
            Guid result = _contactsService.Add("Jose", "01123456789");

            result.Should().NotBe(Guid.Parse("88C3E7C6-B768-4B74-AFFD-4800E9FBD582"));
        }


        [Fact(DisplayName = "Add Mock Fail")]
        [Trait("Category", "Contact Service Tests")]
        public void ContactService_Add_Fail()
        {
            // Arrange
            _contactRepository.Setup(t => t.Add(It.IsAny<Contact>())).Throws(new IOException());

            // Act & Assert
            var ex = Assert.Throws<IOException>(() => _contactsService.Add("Jose", "01123456789"));
            Assert.Equal("I/O error occurred.", ex.Message);
        }


        [Theory(DisplayName = "Update Contact Equal")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("88C3E7C6-B768-4B74-AFFD-4800E9FBD581", "Maria", true)]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A", "Abreu", true)]
        public void ContactService_Update_Equal(string id, string name, bool expectedResult)
        {
            // Arrange
            _contactRepository.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<string>())).Returns(true);

            // Act
            bool result = _contactsService.Update(Guid.Parse(id), name);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory(DisplayName = "Update Contact NotEqual")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("88C3E7C6-B768-4B74-AFFD-4800E9FBD581", "Maria", false)]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A", "Abreu", false)]
        public void ContactService_Update_NotEqual(string id, string name, bool expectedResult)
        {
            // Arrange
            _contactRepository.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<string>())).Returns(false);

            // Act
            bool result = _contactsService.Update(Guid.Parse(id), name);

            // Assert
            Assert.NotEqual(expectedResult, result);
        }

        [Theory(DisplayName = "Update Contact Fail")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A", "Abreu")]
        public void ContactService_Update_Fail(string id, string name)
        {
            // Arrange
            _contactRepository.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<string>())).Throws(new IOException());
            Guid newId = Guid.Parse(id);

            // Act & Assert
            var ex = Assert.Throws<IOException>(() => _contactsService.Update(newId, name));
            Assert.Equal("I/O error occurred.", ex.Message);
        }

        [Theory(DisplayName = "Get Contact Equal")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A")]
        public void ContactService_Get_Equal(string id)
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

        [Theory(DisplayName = "Get Contact NotEqual")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A")]
        public void ContactService_Get_NotEqual(string id)
        {
            // Arrange
            Guid newId = Guid.Parse(id);
            Contact match = new()
            {
                Id = newId,
                Name = "Maria",
                Telephone = new List<string>()
                {
                    "012345678901"
                }
            };

            // Act
            var result = _contactsService.Get(newId);

            // Assert
            result.Should().NotBeEquivalentTo(match);
        }

        [Theory(DisplayName = "Get Contact Fail")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A")]
        public void ContactService_Get_Fail(string id)
        {
            // Arrange
            _contactRepository.Setup(t => t.Get(It.IsAny<Guid>())).Throws(new IOException());
            Guid newId = Guid.Parse(id);

            // Act && Assert
            var ex = Assert.Throws<IOException>(() => _contactsService.Get(newId));
            Assert.Equal("I/O error occurred.", ex.Message);
        }

        [Theory(DisplayName = "Remove Contact Equal")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A")]
        public void ContactService_Remove_Equal(string id)
        {
            // Arrange
            _contactRepository.Setup(t => t.Remove(It.IsAny<Guid>())).Returns(true);
            Guid newId = Guid.Parse(id);

            // Act
            var result = _contactsService.Remove(newId);

            // Assert
            result.Should().BeTrue();
        }

        [Theory(DisplayName = "Remove Contact Equal")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("88C3E7C6-B768-4B74-AFFD-4800E9FBD581")]
        public void ContactService_Remove_NotEqual(string id)
        {
            // Arrange
            _contactRepository.Setup(t => t.Remove(It.IsAny<Guid>())).Returns(false);
            Guid newId = Guid.Parse(id);

            // Act
            var result = _contactsService.Remove(newId);

            // Assert
            result.Should().BeFalse();
        }

        [Theory(DisplayName = "Remove Contact Fail")]
        [Trait("Category", "Contact Service Tests")]
        [InlineData("3096A1C8-5D17-4A06-909E-21B06F788D9A")]
        public void ContactService_Remove_Fail(string id)
        {
            // Arrange
            _contactRepository.Setup(t => t.Remove(It.IsAny<Guid>())).Throws(new IOException());
            Guid newId = Guid.Parse(id);

            // Act
            var ex = Assert.Throws<IOException>(() => _contactsService.Remove(newId));
            Assert.Equal("I/O error occurred.", ex.Message);
        }
    }
}