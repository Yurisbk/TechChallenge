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

        [Fact, Trait("Category", "Integration")]
        public async Task GetAllContacts_ShouldReturnOkResult_WithListOfContacts()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe" };
            await _contactsService.CreateContacts(contactDto);

            // Act
            var result = await _controller.GetAllContacts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnContacts = Assert.IsAssignableFrom<IEnumerable<Contact>>(okResult.Value); 
        }

        [Fact, Trait("Category", "Integration")]
        public async Task CreateContacts_ShouldReturnOkResult_WhenContactIsCreated()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe", Ddd = "11", Ddi = "55", Email = "teste@123.com", Phonenumber = "973645921" };

            // Act
            var result = await _controller.CreateContacts(contactDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact, Trait("Category", "Integration")]
        public async Task CreateContacts_ShouldReturnOkResult_WhenContactIsDeleted()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe", Ddd = "11", Ddi = "55", Email = "teste@123.com", Phonenumber = "973645921" };
            var contactsList = await _contactsService.GetContacts();

            // Act
            if(contactsList is not null)
            {
                var result = await _controller.DeleteContacts(contactsList.FirstOrDefault().id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
            }


        }
    }
}
