using Microsoft.AspNetCore.Mvc;
using Prometheus;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using TechChallenge_ControleContatos.JWT;
using TechChallenge_ControleContatos.Service.DTO;

namespace TechChallenge_ControleContatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        private static readonly Histogram LatencyHistogram = Metrics.CreateHistogram("my_service_latency_seconds", "Histogram of latency in seconds.", new HistogramConfiguration
        {
            Buckets = Histogram.ExponentialBuckets(start: 0.001, factor: 2, count: 10) // e.g., 1ms to 512ms
        });

        /// <summary>
        /// Authenticate user and generate token.
        /// </summary>
        /// <param name="user">User credentials.</param>
        /// <returns>Authentication token.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            var stopwatch = Stopwatch.StartNew();
            var token = await _tokenService.GetToken(user);

            if (!string.IsNullOrWhiteSpace(token))
            {
                System.Threading.Thread.Sleep(new Random().Next(100, 500)); 
                stopwatch.Stop();
                LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
                return Ok(token);
            }
            System.Threading.Thread.Sleep(new Random().Next(100, 500));
            stopwatch.Stop();
            LatencyHistogram.Observe(stopwatch.Elapsed.TotalSeconds);
            return Unauthorized();
        }
    }
    
}
