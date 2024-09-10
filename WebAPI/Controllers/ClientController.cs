using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IRequestQuoteByClient _requestQuoteUseCase;

        public ClientController(IRequestQuoteByClient requestQuoteUseCase)
        {
            _requestQuoteUseCase = requestQuoteUseCase;
        }

        [HttpPost("RequestQuote")]
        public async Task<IActionResult> RequestQuote([FromBody] QuoteRequest request)
        {
            try
            {
                var response = await _requestQuoteUseCase.Handle(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
