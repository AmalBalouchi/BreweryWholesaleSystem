using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using Infrastructure.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrewerController : ControllerBase
    {
        private readonly AddBeerByBrewer _addBeerUseCase;
        private readonly DeleteBeerByBrewer _deleteBeerUseCase;
        private readonly GetBeersByBrewer _getBeersByBrewer;

        public BrewerController(AddBeerByBrewer addBeerUseCase, 
            DeleteBeerByBrewer deleteBeerUseCase, GetBeersByBrewer getBeersByBrewer)
        {
            _addBeerUseCase = addBeerUseCase;
            _deleteBeerUseCase = deleteBeerUseCase;
            _getBeersByBrewer = getBeersByBrewer;
        }

        [HttpPost("AddNewBeer")]
        public async Task<IActionResult> AddBeer([FromBody] Beer beer)
        {
            try
            {
                await _addBeerUseCase.ExecuteAsync(beer.BrewerId, beer);
                return Ok("Beer added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{brewerId}/beers/{beerId}")]
        public async Task<IActionResult> DeleteBeer(int beerId, int brewerId)
        {
            try
            {
                await _deleteBeerUseCase.ExecuteAsync(beerId, brewerId);
                return Ok("Beer deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{brewerId}/beers")]
        public async Task<ActionResult<IEnumerable<Beer>>> GetBeersByBrewer(int brewerId)
        {
            try
            {
                var beers = await _getBeersByBrewer.ExecuteAsync(brewerId);
                return Ok(beers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
