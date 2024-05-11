using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Infra.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly IDbConnection _dbContext;

        public ContactsRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateContacts(string name, string ddi, string ddd, string phone, string email)
        {
            var contact = new Contact
            {
                fullname = name,
                ddi = ddi,
                ddd = ddd,
                phonenumber = phone,
                email = email
            };

            await _dbContext.InsertAsync(contact);
        }

        public async Task DeleteContacts(int id)
        {
            var contact = await _dbContext.GetAsync<Contact>(id);
            if (contact != null)
                await _dbContext.DeleteAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var query = "SELECT * FROM public.contacts_region_view;";

            return await _dbContext.QueryAsync<Contact>(query);
        }

        public async Task<Contact?> GetContactsById(int id)
        {
            var query = $"SELECT * FROM public.contacts_region_view WHERE id = {id};";

            var result = await _dbContext.QueryAsync<Contact>(query);

            return result?.FirstOrDefault();
        }

        public async Task UpdateContacts(int id, string? name, string? ddi, string? ddd, string? phone, string? email)
        {
            var contact = await _dbContext.GetAsync<Contact>(id);
            if (contact != null)
            {
                contact.fullname = name ?? contact.fullname;
                contact.ddi = ddi ?? contact.ddi;
                contact.ddd = ddd ?? contact.ddd;
                contact.phonenumber = phone ?? contact.phonenumber;
                contact.email = email ?? contact.email;

                await _dbContext.UpdateAsync(contact);
            }
        }
    }
}
