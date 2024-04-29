using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;

namespace TechChallenge_ControleContatos.Service.DTO
{
    public class UserDto
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome de usuário não pode ter mais de 50 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Passwordvalue { get; set; }

        [Required(ErrorMessage = "O tipo de função é obrigatório.")]
        public RolesTypes Roletype { get; set; }
    }
}
