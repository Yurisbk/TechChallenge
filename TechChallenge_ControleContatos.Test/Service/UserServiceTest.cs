using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.Service;

namespace TechChallenge_ControleContatos.Test.Service
{
    public class UserServiceTest
    {
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _userService = new UserService(_usersRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateUser_ShouldCallRepository()
        {
            // Arrange
            var userName = "testuser";
            var password = "password123";
            var role = "admin";

            _usersRepositoryMock.Setup(r => r.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                                .Returns(Task.CompletedTask);

            // Act
            await _userService.CreateUser(userName, password, role);

            // Assert
            _usersRepositoryMock.Verify(r => r.CreateUser(userName, password), Times.Once);
        }

        [Fact]
        public async Task GetUser_ShouldReturnUser()
        {
            // Arrange
            var userName = "testuser";
            var password = "password123";
            var user = new Users { username = userName, passwordvalue = password };

            _usersRepositoryMock.Setup(r => r.GetUser(It.IsAny<string>(), It.IsAny<string>()))
                                .ReturnsAsync(user);

            // Act
            var result = await _userService.GetUser(userName, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userName, result.username);
            Assert.Equal(password, result.passwordvalue);
        }

        [Fact]
        public async Task GetUser_ShouldReturnNull_WhenUserNotFound()
        {
            // Arrange
            var userName = "nonexistentuser";
            var password = "wrongpassword";

            _usersRepositoryMock.Setup(r => r.GetUser(It.IsAny<string>(), It.IsAny<string>()))
                                .ReturnsAsync((Users)null);

            // Act
            var result = await _userService.GetUser(userName, password);

            // Assert
            Assert.Null(result);
        }
    }
}
