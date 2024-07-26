using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prometheus;
using System.Diagnostics;
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
        private static readonly Counter SuccessfulRequestsCounter =
        Metrics.CreateCounter("successful_requests_total", "Total number of successful requests");
        private static readonly Counter ErrorRequestsCounter =
        Metrics.CreateCounter("error_requests_total", "Total number of error requests");

        private static readonly Histogram LatencyHistogram = Metrics.CreateHistogram("my_service_latency_seconds", "Histogram of latency in seconds.", new HistogramConfiguration
        {
            Buckets = Histogram.ExponentialBuckets(start: 0.001, factor: 2, count: 10) // e.g., 1ms to 512ms
        });


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
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Iniciando busca de todos os contatos");
            var allContacts = await _contacts.GetContacts();
            SuccessfulRequestsCounter.Inc();
            _logger.LogInformation("Busca de todos os contatos realizada com sucesso");
            System.Threading.Thread.Sleep(new Random().Next(100, 500));
            stopwatch.Stop();
            LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
            return Ok(allContacts);
            
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
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Iniciando busca de um contato por id");
            var contact = await _contacts.GetContactsById(id);
            SuccessfulRequestsCounter.Inc();
            _logger.LogInformation("Busca de um contato por id realizado com sucesso");
            System.Threading.Thread.Sleep(new Random().Next(100, 500));
            stopwatch.Stop();
            LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
            return Ok(contact);
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
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Iniciando criacao de um contato");
            var contactCreated = await _contacts.CreateContacts(contact);

            if(contactCreated.Fullname is null) 
            {
                _logger.LogError("DDD nao relacionado a uma regiao");
                ErrorRequestsCounter.Inc();
                System.Threading.Thread.Sleep(new Random().Next(100, 500));
                stopwatch.Stop();
                LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
                return BadRequest("DDD nao relacionado a uma regiao");
            }

            _logger.LogInformation("Contato criado com sucesso");
            SuccessfulRequestsCounter.Inc();
            System.Threading.Thread.Sleep(new Random().Next(100, 500)); 
            stopwatch.Stop();
            LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
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
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Iniciando edicao de um contato");
            var contactUpdate = await _contacts.UpdateContacts(contact);

            if (contactUpdate == null) 
            {
                _logger.LogError("O contato editado não existe");
                ErrorRequestsCounter.Inc();
                System.Threading.Thread.Sleep(new Random().Next(100, 500));
                stopwatch.Stop();
                LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
                return BadRequest("O contato editado não existe");
            }

            _logger.LogInformation("Contato editado com sucesso");
            SuccessfulRequestsCounter.Inc();
            System.Threading.Thread.Sleep(new Random().Next(100, 500));
            stopwatch.Stop();
            LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
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
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Iniciando delecao de um contato");
            await _contacts.DeleteContacts(id);
            _logger.LogInformation("Contato deletado com sucesso");
            SuccessfulRequestsCounter.Inc();
            System.Threading.Thread.Sleep(new Random().Next(100, 500));
            stopwatch.Stop();
            LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
            return Ok("Contato deletado com sucesso");
        }
    }
}
