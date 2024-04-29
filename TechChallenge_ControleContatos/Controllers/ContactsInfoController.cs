using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Service.DTO;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsInfoController : ControllerBase
    {
        public readonly IContactsService _contacts;

        public ContactsInfoController(IContactsService contacts)
        {
            _contacts = contacts;
        }

        [HttpGet("GetAllContacts")]
        [Authorize]
        public async Task<IActionResult> GetAllContacts()
        {
           return Ok(await _contacts.GetContacts());
        }

        [HttpPost("CreateContact")]
        [Authorize]
        public async Task<IActionResult> CreateContacts(ContactDto contact)
        {
            await _contacts.CreateContacts(contact);
            return Ok();
        }

        [HttpPut("UpdateContact")]
        [Authorize]
        public async Task<IActionResult> UpdateContacts([FromBody] ContactDto contact)
        {
            await _contacts.UpdateContacts(contact);
            return Ok();
        }

        [HttpDelete("DeleteContact")]
        [Authorize]
        public async Task<IActionResult> DeleteContacts(int id)
        {
            await _contacts.DeleteContacts(id);
            return Ok("Deletado com sucesso");
        }

    }
}
