using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Mapping;

namespace TechChallenge_ControleContatos.Service.Interface
{
    public interface IContactsRepository
    {
        public Task<IEnumerable<Contact>> GetContacts(); 
        public Task<Contact> GetContactsById(int id);
        public Task CreateContacts(string name, string ddi, string ddd, string phone, string email);
        public Task UpdateContacts(int id, string? name, string? ddi, string? ddd, string? phone, string? email);
        public Task DeleteContacts(int id);
    }
}
