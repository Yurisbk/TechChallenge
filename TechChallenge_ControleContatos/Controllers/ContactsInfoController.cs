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
        public async Task<IActionResult> GetAllContacts()
        {
           return Ok(await _contacts.GetContacts());
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContacts(ContactDto contact)
        {
            await _contacts.CreateContacts(contact);
            return Ok();
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContacts(int id, [FromBody] ContactDto contact)
        {
            _contacts.UpdateContacts(id, contact);
            return Ok();
        }

        [HttpDelete("DeleteContact")]
        public async Task<IActionResult> DeleteContacts(int id)
        {
            await _contacts.DeleteContacts(id);
            return Ok("Deletado com sucesso");
        }

    }
}
