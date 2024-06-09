using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Service.DTO;

namespace TechChallenge_ControleContatos.JWT
{
    public interface ITokenService
    {
            public Task<string> GetToken(UserDto users);
    }
}
