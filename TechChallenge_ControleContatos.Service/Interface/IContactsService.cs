using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.DTO;

namespace TechChallenge_ControleContatos.Service.Interface
{
    public interface IContactsService
    {
        public Task<IEnumerable<Contact>> GetContacts();
        public Task<Contact> GetContactsById(int id);
        public Task CreateContacts(ContactDto contact);
        public Task UpdateContacts(ContactDto contact);
        public Task DeleteContacts(int id);
    }
}
