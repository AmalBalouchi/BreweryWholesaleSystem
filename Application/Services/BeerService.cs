using Domain.Entities;
using Domain.Interfaces;

public class BeerService
{
    private readonly IBeerRepository _beerRepository;

    public BeerService(IBeerRepository beerRepository)
    {
        _beerRepository = beerRepository;
    }

    public async Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId)
    {
        return await _beerRepository.GetBeersByBrewer(brewerId);
    }

    public async Task AddBeer(Beer beer, Guid brewerId)
    {
        await _beerRepository.AddBeerByBrewer(beer, brewerId);
    }

    public async Task DeleteBeer(Beer beer, Guid brewerId)
    {
        await _beerRepository.DeleteBeerByBrewer(beer, brewerId);
    }

}
