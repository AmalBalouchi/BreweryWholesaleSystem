using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BeerController : ControllerBase
{
    private readonly BeerService _beerService;

    public BeerController(BeerService beerService)
    {
        _beerService = beerService;
    }

    [HttpGet("{brewerId}")]
    public async Task<IActionResult> GetBeersByBrewer(int brewerId)
    {
        var beers = await _beerService.GetBeersByBrewer(brewerId);
        return Ok(beers);
    }

    [HttpPost("{brewerId}")]
    public async Task<IActionResult> AddBeer([FromBody] Beer beer, int brewerId)
    {
        await _beerService.AddBeer(beer, brewerId);
        return CreatedAtAction(nameof(GetBeersByBrewer), new { brewerId = brewerId }, beer);
    }

    [HttpDelete("{brewerId}/{beerId}")]
    public async Task<IActionResult> DeleteBeer(int brewerId, int beerId)
    {
        var beer = new Beer { Id = beerId };
        await _beerService.DeleteBeer(beer, brewerId);
        return NoContent();
    }

}
