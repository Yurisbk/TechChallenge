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
            var query = $@"INSERT INTO public.contacts(
	                    fullname, ddi, ddd, phonenumber, email)
	                    VALUES ('{name}','{ddi}','{ddd}','{phone}','{email}');";
            await _dbContext.ExecuteAsync(query);
        }

        public async Task DeleteContacts(int Id)
        {
            var contactList = await GetContacts();
            var contact = contactList.FirstOrDefault(x => x.id.Equals(Id));

            if(contact != null)
                await _dbContext.DeleteAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var query = @"SELECT id, fullname, ddi, ddd, phonenumber, email, region
	                       FROM public.contacts_region_view;";

            return await _dbContext.QueryAsync<Contact>(query);
        }

        public async Task UpdateContacts(int id, string? name, string? ddi, string? ddd, string? phone, string? email)
        {
            var contact = new Contact()
            {
                id = id,
                fullname = name,
                ddi = ddi,
                ddd = ddd,
                phonenumber = phone,
                email = email
            };

            await _dbContext.UpdateAsync(contact);
        }
    }
}
