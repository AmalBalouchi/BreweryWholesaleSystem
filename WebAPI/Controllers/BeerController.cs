using Application.Services;
using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BeerController : ControllerBase
{
    private readonly GetBeersByBrewer _getBeersByBrewer;

    public BeerController(GetBeersByBrewer getBeersByBrewer)
    {
        _getBeersByBrewer = getBeersByBrewer;
    }

    [HttpGet("{brewerId}/beers")]
    [Route("GetBeersByBrewer")]
    public async Task<ActionResult<IEnumerable<Beer>>> GetBeersByBrewer(Guid brewerId)
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
