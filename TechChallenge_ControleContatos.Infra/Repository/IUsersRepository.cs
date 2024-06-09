using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Mapping;

namespace TechChallenge_ControleContatos.Infra.Repository
{
    public interface IUsersRepository
    {
        public Task<Users> GetUser(string userName, string password);
        public Task CreateUser(string userName, string password);
    }
}
