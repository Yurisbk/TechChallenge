using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Service.Service
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task CreateContacts(ContactDto contacts)
        {
            await _contactsRepository.CreateContacts(contacts.Fullname, contacts.Ddi, contacts.Ddd, contacts.Phonenumber ,contacts.Email);
        }

        public async Task DeleteContacts(int Id)
        {
            await _contactsRepository.DeleteContacts(Id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var x = await _contactsRepository.GetContacts();

            return x;
        }

        public async Task UpdateContacts(ContactDto contacts)
        {
            await _contactsRepository.UpdateContacts(contacts.Id, contacts.Fullname, contacts.Ddi, contacts.Ddd, contacts.Phonenumber, contacts.Email);
        }
    }
}
