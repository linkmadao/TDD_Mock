using FluentAssertions;
using TDD.Mock.DAL;
using TDD.Mock.Domain;

namespace TDD.Mock.Services.Tests
{
    public class UsersServiceTest
    {
        private readonly UsersService _usersService;

        public UsersServiceTest()
        {
            _usersService = new UsersService();
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
                Name = "Jose",
                CPF = "1",
                Username = "jose",
                Password = "021568#@aA",
                Email = "jose@teste.com"
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
                Name = "Jose",
                CPF = "12345678901",
                Username = "jose",
                Password = "021568#@aA",
                Email = "jose@teste.com"
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
                // Verificar se o método foi executado
                ex.Message.Should().Be("Invalid CPF");
            }
        }
    }
}