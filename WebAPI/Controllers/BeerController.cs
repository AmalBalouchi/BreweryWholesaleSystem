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

    [HttpGet("ListAllBeersGroupedByBrewer")]
    public async Task<ActionResult<IDictionary<int, List<Beer>>>> GetAllBeersGroupedByBrewery()
    {
        var groupedBeers = await _listAllBeersGroupedByBrewery.Execute();
        return Ok(groupedBeers);
    }
}
