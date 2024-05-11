using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge_ControleContatos.Service.DTO
{
    public class ContactDto
    {
        
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome completo não pode ter mais de 100 caracteres.")]
        public string? Fullname { get; set; }

        [Required(ErrorMessage = "O DDI é obrigatório.")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O DDI deve ter entre 1 e 3 caracteres.")]
        public string? Ddi { get; set; }

        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O DDD deve ter entre 1 e 3 caracteres.")]
        public string? Ddd { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [MaxLength(9, ErrorMessage = "O número de telefone não pode ter mais de 9 caracteres.")]
        public string? Phonenumber { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não está em um formato válido.")]
        public string? Email { get; set; }
    }
}
