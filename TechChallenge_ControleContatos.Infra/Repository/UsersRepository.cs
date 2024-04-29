using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Mapping;

namespace TechChallenge_ControleContatos.Infra.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnection _dbContext;

        public UsersRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUser(string userName, string password, string role)
        {
            var query = $@"INSERT INTO users(username, passwordvalue, roletype) VALUES
                         ('{userName}', '{password}', '{role}');";

             await _dbContext.ExecuteAsync(query);
        }

        public async Task<Users> GetUser(string userName, string password)
        {
            return await _dbContext.QueryFirstOrDefaultAsync<Users>($@"Select * from users where username = '{userName}' and passwordvalue = '{password}'");
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

            if (contact != null)
                await _dbContext.DeleteAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var query = @"SELECT * FROM public.contacts_region_view;";

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
