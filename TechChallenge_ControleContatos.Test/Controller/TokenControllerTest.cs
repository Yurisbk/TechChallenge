using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Controllers;
using TechChallenge_ControleContatos.JWT;
using TechChallenge_ControleContatos.Service.DTO;

namespace TechChallenge_ControleContatos.Test.Controller
{
    public class TokenControllerTest
    {
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly TokenController _controller;

        public TokenControllerTest()
        {
            _tokenServiceMock = new Mock<ITokenService>();
            _controller = new TokenController(_tokenServiceMock.Object);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task Post_ShouldReturnOkResult_WithToken_WhenUserAuthenticationIsSuccessful()
        {
            // Arrange
            var user = new UserDto { Username = "testuser", Passwordvalue = "testpassword" };
            var expectedToken = "abc123";
            _tokenServiceMock.Setup(service => service.GetToken(user)).ReturnsAsync(expectedToken);

            // Act
            var result = await _controller.Post(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedToken, okResult.Value);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task Post_ShouldReturnUnauthorizedResult_WhenUserAuthenticationFails()
        {
            // Arrange
            var user = new UserDto { Username = "invaliduser", Passwordvalue = "invalidpassword" };
            _tokenServiceMock.Setup(service => service.GetToken(user)).ReturnsAsync((string)null);

            // Act
            var result = await _controller.Post(user);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
