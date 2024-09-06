using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class GetBeersByBrewer
    {
        private readonly IBeerRepository _beerRepository;

        public GetBeersByBrewer(IBeerRepository beerRepository) //Dependency injection of IBeerRepository
        {
            _beerRepository = beerRepository;
        }

        public async Task<IEnumerable<Beer>> ExecuteAsync(int brewerId)
        {
            return await _beerRepository.GetBeersByBrewer(brewerId);
        }
    }
}
