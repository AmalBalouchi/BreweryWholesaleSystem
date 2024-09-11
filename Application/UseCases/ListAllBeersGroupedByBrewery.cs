using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class ListAllBeersGroupedByBrewery
    {
        private readonly IBeerRepository _beerRepository;

        public ListAllBeersGroupedByBrewery(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<IDictionary<int, List<Beer>>> Execute()
        {
            var beers = await _beerRepository.GetAllBeers();
            var groupedBeers = beers.GroupBy(b => b.BrewerId)
                                    .ToDictionary(g => g.Key, g => g.ToList());

            return groupedBeers;
        }
    }
}
