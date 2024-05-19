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

        public async Task CreateUser(string userName, string password)
        {
            var user = new Users
            {
                username = userName,
                passwordvalue = password
            };

            await _dbContext.InsertAsync(user);
        }

        public async Task<Users> GetUser(string userName, string password)
        {
            return await _dbContext.QueryFirstOrDefaultAsync<Users>(
                "SELECT * FROM users WHERE username = @UserName AND passwordvalue = @Password",
                new { UserName = userName, Password = password });
        }
    }
}
