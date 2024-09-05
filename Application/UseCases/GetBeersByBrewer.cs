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
        private readonly IBreweryRepository _breweryRepository;

        public GetBeersByBrewer(IBreweryRepository breweryRepository) //Dependency injection of IBeerRepository
        {
            _breweryRepository = breweryRepository;
        }

        /*public async Task<IEnumerable<Beer>> ExecuteAsync(int breweryId)
        {
            return await _breweryRepository.GetBeersByBrewer(breweryId);
        }*/
    }
}
