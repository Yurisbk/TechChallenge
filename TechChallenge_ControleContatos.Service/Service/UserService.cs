using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Service.Service
{
    public class UserService : IUsersService
    {
        public readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task CreateUser(string userName, string password, string role)
        {
            await _usersRepository.CreateUser(userName, password);
        }

        public async Task<Users> GetUser(string userName, string password)
        {
            return await _usersRepository.GetUser(userName, password);
        }
    }
}
