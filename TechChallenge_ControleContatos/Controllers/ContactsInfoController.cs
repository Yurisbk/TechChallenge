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

        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>List of contacts.</returns>
        [HttpGet("GetAllContacts")]
        [Authorize]
        public async Task<IActionResult> GetAllContacts()
        {
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
            await _contacts.DeleteContacts(id);
            return Ok("Deleted successfully");
        }
    }
}
