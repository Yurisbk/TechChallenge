using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Controllers;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Test.Controller
{
    public class ContactsInfoControllerTests
    {
        private readonly Mock<IContactsService> _contactsServiceMock;
        private readonly Mock<ILogger<ContactsInfoController>> _loggerMock;
        private readonly ContactsInfoController _controller;

        public ContactsInfoControllerTests()
        {
            _contactsServiceMock = new Mock<IContactsService>();
            _loggerMock = new Mock<ILogger<ContactsInfoController>>();
            _controller = new ContactsInfoController(_contactsServiceMock.Object, _loggerMock.Object);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task GetAllContacts_ShouldReturnOkResult_WithListOfContacts()
        {
            // Arrange
            var contacts = new List<Contact> { new Contact { id = 1, fullname = "John Doe" } };
            _contactsServiceMock.Setup(service => service.GetContacts()).ReturnsAsync(contacts);

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
            var contact = new Contact { id = 1, fullname = "John Doe" };
            _contactsServiceMock.Setup(service => service.GetContactsById(1)).ReturnsAsync(contact);

            // Act
            var result = await _controller.GetContact(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(contact.id, returnContact.id);
        }

        [Fact, Trait("Category", "Unity")]
        public async Task CreateContacts_ShouldReturnOkResult_WhenContactIsCreated()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };
            _contactsServiceMock.Setup(service => service.CreateContacts(contactDto)).ReturnsAsync(contactDto);

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
            _contactsServiceMock.Setup(service => service.CreateContacts(contactDto)).ReturnsAsync(contactDto);

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
            var contact = new Contact { id = 1, fullname = "John Doe" };
            _contactsServiceMock.Setup(service => service.UpdateContacts(contactDto)).ReturnsAsync(contact);

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
            _contactsServiceMock.Setup(service => service.UpdateContacts(contactDto)).ReturnsAsync((Contact)null);

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
            var contactId = 1;
            _contactsServiceMock.Setup(service => service.DeleteContacts(contactId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteContacts(contactId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Contato deletado com sucesso", okResult.Value);
        }
    }

}
