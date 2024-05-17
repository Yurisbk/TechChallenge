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
        private readonly IContactsService _contacts;
        private readonly ILogger<ContactsInfoController> _logger;

        public ContactsInfoController(IContactsService contacts, ILogger<ContactsInfoController> logger)
        {
            _contacts = contacts;
            _logger = logger;
        }

        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>List of contacts.</returns>
        [HttpGet("GetAllContacts")]
        [Authorize]
        public async Task<IActionResult> GetAllContacts()
        {
            _logger.LogInformation("Iniciando busca de todos os contatos");
            return Ok(await _contacts.GetContacts());
        }

        /// <summary>
        /// Get a contact by ID.
        /// </summary>
        /// <param name="id">Contact ID.</param>
        /// <returns>Contact details.</returns>
        [HttpGet("GetContact")]
        [Authorize]
        public async Task<IActionResult> GetContact(int id)
        {
            _logger.LogInformation("Iniciando busca de um contato por id");
            return Ok(await _contacts.GetContactsById(id));
        }

        /// <summary>
        /// Create a new contact.
        /// </summary>
        /// <param name="contact">Contact details to create.</param>
        /// <returns>Success response.</returns>
        [HttpPost("CreateContact")]
        [Authorize]
        public async Task<IActionResult> CreateContacts(ContactDto contact)
        {
            _logger.LogInformation("Iniciando criacao de um contato");
            await _contacts.CreateContacts(contact);
            return Ok();
        }

        /// <summary>
        /// Update an existing contact.
        /// </summary>
        /// <param name="contact">Updated contact details.</param>
        /// <returns>Success response.</returns>
        [HttpPut("UpdateContact")]
        [Authorize]
        public async Task<IActionResult> UpdateContacts([FromBody] ContactDto contact)
        {
            _logger.LogInformation("Iniciando edicao de um contato");
            await _contacts.UpdateContacts(contact);
            return Ok();
        }

        /// <summary>
        /// Delete a contact by ID.
        /// </summary>
        /// <param name="id">ID of the contact to delete.</param>
        /// <returns>Success response.</returns>
        [HttpDelete("DeleteContact")]
        [Authorize]
        public async Task<IActionResult> DeleteContacts(int id)
        {
            _logger.LogInformation("Iniciando delecao de um contato");
            await _contacts.DeleteContacts(id);
            return Ok("Deleted successfully");
        }
    }
}
