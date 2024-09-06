using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BrewerService
    {
        private readonly IBrewerRepository _brewerRepository;

        public BrewerService(IBrewerRepository brewerRepository)
        {
            _brewerRepository = brewerRepository;
        }

        public async Task AddBeerAsync(Beer newBeer)
        {
            await _brewerRepository.AddBeer(newBeer);
        }

        public async Task DeleteBeerAsync(int beerId)
        {
            await _brewerRepository.DeleteBeer(beerId);
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewerAsync(int brewerId)
        {
            return await _brewerRepository.GetBeersByBrewer(brewerId);
        }
    }
}
