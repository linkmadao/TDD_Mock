namespace TDD.Mock.Services.Tests
{
    public class UsersServiceTest
    {
        public UsersServiceTest()
        {
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
 
            // Act
            // Tentar realizar cadastro do usuário

            // Assert
            // Retornar erro de argumento de CPF Inválido
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

            // Act
            // Tentar realizar cadastro do usuário

            // Assert
            // Verificar se o método foi executado
        }
    }
}