using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;
using TechChallenge_ControleContatos.Service.Service;

namespace TechChallenge_ControleContatos.JWT
{
    public class TokenService : ITokenService
    {
            
        private readonly IConfiguration _configuration;
        private readonly IUsersService _userService;
        public TokenService(IConfiguration configuration, IUsersService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<string> GetToken(UserDto user)
        {
            var userDB = await _userService.GetUser(user.Username, user.Passwordvalue);

            if (userDB is null || userDB.username is null)
                return string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, (user.Roletype - 1).ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(5),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);

        }
    }
}

