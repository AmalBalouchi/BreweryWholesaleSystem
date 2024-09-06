using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BeerController : ControllerBase
{
    private readonly BrewerService _brewerService;

    public BeerController(BrewerService brewerService)
    {
        _brewerService = brewerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBeer([FromBody] Beer beer)
    {
        await _brewerService.AddBeerAsync(beer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBeer(int id)
    {
        await _brewerService.DeleteBeerAsync(id);
        return Ok();
    }

    [HttpGet("by-brewer/{brewerId}")]
    public async Task<IActionResult> GetBeersByBrewer(int brewerId)
    {
        var beers = await _brewerService.GetBeersByBrewerAsync(brewerId);
        return Ok(beers);
    }
}
