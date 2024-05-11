using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;
using TechChallenge_ControleContatos.Service.Service;

namespace TechChallenge_ControleContatos.Test
{
    public class ContactServiceTest
    {
        [Fact]
        public async Task CreateContacts_ValidContact_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            var mockRepository = new Mock<IContactsRepository>();
            var service = new ContactsService(mockRepository.Object);
            var contactDto = new ContactDto
            {
                Fullname = "John Doe",
                Ddi = "1",
                Ddd = "999",
                Phonenumber = "123456789",
                Email = "john@example.com"
            };

            // Act
            await service.CreateContacts(contactDto);

            // Assert
            mockRepository.Verify(r => r.CreateContacts(
                contactDto.Fullname, contactDto.Ddi, contactDto.Ddd, contactDto.Phonenumber, contactDto.Email), Times.Once);
        }

        [Fact]
        public async Task DeleteContacts_ValidId_CallsRepositoryWithCorrectId()
        {
            // Arrange
            var mockRepository = new Mock<IContactsRepository>();
            var service = new ContactsService(mockRepository.Object);
            int contactId = 1;

            // Act
            await service.DeleteContacts(contactId);

            // Assert
            mockRepository.Verify(r => r.DeleteContacts(contactId), Times.Once);
        }

        [Fact]
        public async Task GetContacts_ReturnsOrderedContacts()
        {
            // Arrange
            var mockRepository = new Mock<IContactsRepository>();
            var service = new ContactsService(mockRepository.Object);
            var contacts = new List<Contact>
        {
            new Contact { id = 3, fullname = "Alice" },
            new Contact { id = 1, fullname = "Bob" },
            new Contact { id = 2, fullname = "Charlie" }
        };
            mockRepository.Setup(r => r.GetContacts()).ReturnsAsync(contacts);

            // Act
            var result = await service.GetContacts();

            // Assert
            Assert.Equal(contacts.OrderBy(x => x.id), result);
        }

        [Fact]
        public async Task GetContactsById_ValidId_ReturnsCorrectContact()
        {
            // Arrange
            var mockRepository = new Mock<IContactsRepository>();
            var service = new ContactsService(mockRepository.Object);
            int contactId = 1;
            var contact = new Contact { id = contactId, fullname = "John Doe" };
            mockRepository.Setup(r => r.GetContactsById(contactId)).ReturnsAsync(contact);

            // Act
            var result = await service.GetContactsById(contactId);

            // Assert
            Assert.Equal(contact, result);
        }

        [Fact]
        public async Task UpdateContacts_ValidContact_CallsRepositoryWithCorrectParameters()
        {
            // Arrange
            var mockRepository = new Mock<IContactsRepository>();
            var service = new ContactsService(mockRepository.Object);
            var contactDto = new ContactDto
            {
                Id = 1,
                Fullname = "Updated Name",
                Ddi = "1",
                Ddd = "999",
                Phonenumber = "123456789",
                Email = "john@example.com"
            };

            // Act
            await service.UpdateContacts(contactDto);

            // Assert
            mockRepository.Verify(r => r.UpdateContacts(
                contactDto.Id, contactDto.Fullname, contactDto.Ddi, contactDto.Ddd, contactDto.Phonenumber, contactDto.Email), Times.Once);
        }
    }
}
