using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;
using TechChallenge_ControleContatos.Service.Service;

namespace TechChallenge_ControleContatos.Test.Service
{
    public class ContactsServiceTests
    {
        private readonly Mock<IContactsRepository> _contactsRepositoryMock;
        private readonly Mock<IRegionsRepository> _regionsRepositoryMock;
        private readonly ContactsService _contactsService;

        public ContactsServiceTests()
        {
            _contactsRepositoryMock = new Mock<IContactsRepository>();
            _regionsRepositoryMock = new Mock<IRegionsRepository>();
            _contactsService = new ContactsService(_contactsRepositoryMock.Object, _regionsRepositoryMock.Object);
        }

        [Fact, Category("Unity")]
        public async Task CreateContacts_ShouldReturnEmptyDto_WhenRegionIsNull()
        {
            // Arrange
            var contactDto = new ContactDto { Ddd = "011" };
            _regionsRepositoryMock.Setup(r => r.GetRegionByDdd(It.IsAny<string>()))
                                  .ReturnsAsync((Regions)null);

            // Act
            var result = await _contactsService.CreateContacts(contactDto);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Fullname);
        }

        [Fact, Category("Unity")]
        public async Task CreateContacts_ShouldCallRepositoryAndReturnDto_WhenRegionIsNotNull()
        {
            // Arrange
            var contactDto = new ContactDto { Fullname = "John Doe", Ddd = "011", Ddi = "55", Phonenumber = "123456789", Email = "john.doe@example.com" };
            var region = new Regions();
            _regionsRepositoryMock.Setup(r => r.GetRegionByDdd(It.IsAny<string>()))
                                  .ReturnsAsync(region);
            _contactsRepositoryMock.Setup(r => r.CreateContacts(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                                  .Returns(Task.CompletedTask);

            // Act
            var result = await _contactsService.CreateContacts(contactDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(contactDto.Fullname, result.Fullname);
            _contactsRepositoryMock.Verify(r => r.CreateContacts(contactDto.Fullname, contactDto.Ddi, contactDto.Ddd, contactDto.Phonenumber, contactDto.Email), Times.Once);
        }

        [Fact, Category("Unity")]
        public async Task DeleteContacts_ShouldCallRepository()
        {
            // Arrange
            var contactId = 1;
            _contactsRepositoryMock.Setup(r => r.DeleteContacts(contactId))
                                  .Returns(Task.CompletedTask);

            // Act
            await _contactsService.DeleteContacts(contactId);

            // Assert
            _contactsRepositoryMock.Verify(r => r.DeleteContacts(contactId), Times.Once);
        }

        [Fact, Category("Unity")]
        public async Task GetContacts_ShouldReturnOrderedDistinctContacts()
        {
            // Arrange
            var contacts = new List<Contact>
        {
            new Contact { id = 2, fullname = "Alice" },
            new Contact { id = 1, fullname = "Bob" },
            new Contact { id = 1, fullname = "Bob" }
        };
            _contactsRepositoryMock.Setup(r => r.GetContacts())
                                  .ReturnsAsync(contacts);

            // Act
            var result = await _contactsService.GetContacts();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Bob", result.First().fullname);
        }

        [Fact, Category("Unity")]
        public async Task GetContactsById_ShouldReturnContact()
        {
            // Arrange
            var contact = new Contact { id = 1, fullname = "John Doe" };
            _contactsRepositoryMock.Setup(r => r.GetContactsById(contact.id))
                                  .ReturnsAsync(contact);

            // Act
            var result = await _contactsService.GetContactsById(contact.id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(contact.fullname, result.fullname);
        }

        [Fact, Category("Unity")]
        public async Task UpdateContacts_ShouldReturnUpdatedContact()
        {
            // Arrange
            var contactDto = new ContactDto { Id = 1, Fullname = "John Doe", Ddi = "55", Ddd = "011", Phonenumber = "123456789", Email = "john.doe@example.com" };
            var updatedContact = new Contact { id = 1, fullname = "John Doe" };
            _contactsRepositoryMock.Setup(r => r.UpdateContacts(contactDto.Id, contactDto.Fullname, contactDto.Ddi, contactDto.Ddd, contactDto.Phonenumber, contactDto.Email))
                                  .ReturnsAsync(updatedContact);

            // Act
            var result = await _contactsService.UpdateContacts(contactDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedContact.fullname, result.fullname);
        }
    }
}
