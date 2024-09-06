using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AddBeerByBrewer
    {

        private readonly IBeerRepository _beerRepository;
        private readonly IBeerService _beerService;

        //Dependency injection of IBrewerRepository and IBeerService
        public AddBeerByBrewer(IBeerRepository beerRepository, IBeerService beerService) 
        {
            _beerRepository = beerRepository;
            _beerService = beerService;
        }

        public async Task ExecuteAsync(Beer newBeer, Guid brewerId)
        {
            // Validate the beer using the service
            await _beerService.ValidateBeerAsync(newBeer);

            // Add the beer using the repository
            await _beerRepository.AddBeerByBrewer(newBeer, brewerId);
        }

    }
}
