
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.Service;

namespace TechChallenge_ControleContatos.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task CreateUser_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var service = new UserService(mockRepository.Object);
            string userName = "testuser";
            string password = "testpassword";

            // Act
            await service.CreateUser(userName, password, "UserRole");

            // Assert
            mockRepository.Verify(r => r.CreateUser(userName, password), Times.Once);
        }

        [Fact]
        public async Task GetUser_ReturnsUserFromRepository()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var service = new UserService(mockRepository.Object);
            string userName = "testuser";
            string password = "testpassword";
            var expectedUser = new Users { id = 1, username = userName, passwordvalue = password };
            mockRepository.Setup(r => r.GetUser(userName, password)).ReturnsAsync(expectedUser);

            // Act
            var result = await service.GetUser(userName, password);

            // Assert
            Assert.Equal(expectedUser, result);
        }
    }
}