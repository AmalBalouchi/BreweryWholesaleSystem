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

        public AddBeerByBrewer(IBeerRepository beerRepository) //Dependency injection of IBeerRepository
            {
                _beerRepository = beerRepository;
            }

        /*public async Task ExecuteAsync(Beer beer)
            {
                await _beerRepository.AddAsync(beer);
            }*/

    }
}
