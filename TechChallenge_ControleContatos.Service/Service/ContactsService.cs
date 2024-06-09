using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Service.Service
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IRegionsRepository _regions;

        public ContactsService(IContactsRepository contactsRepository, IRegionsRepository regions)
        {
            _contactsRepository = contactsRepository;
            _regions = regions;
        }

        public async Task<ContactDto> CreateContacts(ContactDto contacts)
        {
            var regions = await _regions.GetRegionByDdd(contacts.Ddd);

            if (regions is null)
                return new ContactDto();

            await _contactsRepository.CreateContacts(contacts.Fullname, contacts.Ddi, contacts.Ddd, contacts.Phonenumber ,contacts.Email);

            return contacts;
        }

        public async Task DeleteContacts(int Id)
        {
            await _contactsRepository.DeleteContacts(Id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            IEnumerable<Contact> contacts = await _contactsRepository.GetContacts();
            return contacts.OrderBy(x => x.id)
                           .DistinctBy(x => x.fullname);
        }

        public async Task<Contact> GetContactsById(int id)
        {
            return await _contactsRepository.GetContactsById(id);
        }

        public async Task<Contact> UpdateContacts(ContactDto contacts)
        {
            var contactUpdated = await _contactsRepository.UpdateContacts(contacts.Id, contacts.Fullname, contacts.Ddi, contacts.Ddd, contacts.Phonenumber, contacts.Email);

            return contactUpdated;
        }
    }
}
