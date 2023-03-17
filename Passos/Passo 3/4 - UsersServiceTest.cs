using FluentAssertions;
using Moq;
using Moq.AutoMock;
using TDD.Mock.DAL;
using TDD.Mock.Domain;

namespace TDD.Mock.Services.Tests
{
    public class UsersServiceTest
    {
        private readonly Faker _faker;
        private readonly AutoMocker _mocker;
        private readonly UsersService _usersService;

        public UsersServiceTest()
        {
            _faker = new Faker("pt_BR");
            _mocker = new AutoMocker();
            _usersService = _mocker.CreateInstance<UsersService>();
        }

        [Fact]
        public async Task UserService_Create_InvalidCPF()
        {
            // Arrange
            // Usuário contem os campos:
            //  - Name
            //  - CPF (menos do que 11 caracteres)
            //  - Username
            //  - Password
            //  - Email
            User user = new()
            {
                Name = _faker.Name.FullName(),
                CPF = _faker.Random.AlphaNumeric(1),
                Username = _faker.Internet.UserName(),
                Password = _faker.Internet.Password(8),
                Email = _faker.Internet.Email()
            };
 
            try
            {
                // Act
                // Tentar realizar cadastro do usuário
                await _usersService.Create(user);
            }
            catch(ArgumentException ex)
            {
                // Assert
                // Retornar erro de argumento de CPF Inválido
                ex.Message.Should().Be("Invalid CPF");
            }
        }

        [Fact]
        public async Task User_Attributes_Success()
        {
            // Arrange
            // Usuário contem os campos:
                //  - Name
                //  - CPF
                //  - Username
                //  - Password
                //  - Email
           User user = new()
            {
                Name = _faker.Name.FullName(),
                CPF = _faker.Random.AlphaNumeric(11),
                Username = _faker.Internet.UserName(),
                Password = _faker.Internet.Password(8),
                Email = _faker.Internet.Email()
            };

            _mocker.GetMock<IUsersRepository>().Setup(t => t.Create(It.IsAny<User>()));

            // Act
            // Tentar realizar cadastro do usuário
            await _usersService.Create(user);

            // Assert
            // Verificar se o método foi executado
            _mocker.GetMock<IUsersRepository>().Verify(t => t.Create(It.IsAny<User>()),Times.Once());
        }
    }
}