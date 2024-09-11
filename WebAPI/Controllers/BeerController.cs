using Application.Services;
using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BeerController : ControllerBase
{
    private readonly GetBeersByBrewer _getBeersByBrewer;
    private readonly ListAllBeersGroupedByBrewery _listAllBeersGroupedByBrewery;

    public BeerController(GetBeersByBrewer getBeersByBrewer, ListAllBeersGroupedByBrewery listAllBeersGroupedByBrewery)
    {
        _getBeersByBrewer = getBeersByBrewer;
        _listAllBeersGroupedByBrewery = listAllBeersGroupedByBrewery;
    }

    [HttpGet("{brewerId}/beers")]
    public async Task<ActionResult<IEnumerable<Beer>>> GetBeers(int brewerId)
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

    [HttpGet("grouped-by-brewery")]
    public async Task<ActionResult<IDictionary<int, List<Beer>>>> GetAllBeersGroupedByBrewery()
    {
        var groupedBeers = await _listAllBeersGroupedByBrewery.Execute();
        return Ok(groupedBeers);
    }
}
