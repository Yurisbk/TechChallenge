using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Controllers;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;
using Xunit;

namespace TechChallenge_ControleContatos.Test.Controller
{
    public class ContactsInfoTests : IClassFixture<DatabaseFixture>
    {
        private readonly IContactsService _contactsService;
        private readonly ILogger<ContactsInfoController> _logger;
        private readonly ContactsInfoController _controller;

        public ContactsInfoTests(DatabaseFixture fixture)
        {
            _contactsService = fixture.ContactsService;
            _logger = fixture.Logger;
            _controller = new ContactsInfoController(_contactsService, _logger);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task GetAllContacts_ShouldReturnOkResult_WithListOfContacts()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };
            await _contactsService.CreateContacts(contactDto);

            // Act
            var result = await _controller.GetAllContacts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnContacts = Assert.IsType<List<Contact>>(okResult.Value);
            Assert.Single(returnContacts);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task GetContact_ShouldReturnOkResult_WithContact()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };
            await _contactsService.CreateContacts(contactDto);

            // Act
            var result = await _controller.GetContact(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(contactDto.Id, returnContact.id);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task CreateContacts_ShouldReturnOkResult_WhenContactIsCreated()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };

            // Act
            var result = await _controller.CreateContacts(contactDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task CreateContacts_ShouldReturnBadRequest_WhenContactCreationFails()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 0, Fullname = null };

            // Act
            var result = await _controller.CreateContacts(contactDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("DDD nao relacionado a uma regiao", badRequestResult.Value);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task UpdateContacts_ShouldReturnOkResult_WhenContactIsUpdated()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };
            await _contactsService.CreateContacts(contactDto);

            // Act
            var result = await _controller.UpdateContacts(contactDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task UpdateContacts_ShouldReturnBadRequest_WhenContactDoesNotExist()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };

            // Act
            var result = await _controller.UpdateContacts(contactDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("O contato editado não existe", badRequestResult.Value);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task DeleteContacts_ShouldReturnOkResult_WhenContactIsDeleted()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };
            await _contactsService.CreateContacts(contactDto);

            // Act
            var result = await _controller.DeleteContacts(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Contato deletado com sucesso", okResult.Value);
        }
    }
}
