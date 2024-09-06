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

        private readonly IBrewerRepository _brewerRepository;

        public AddBeerByBrewer(IBrewerRepository brewerRepository) //Dependency injection of IBrewerRepository
        {
            _brewerRepository = brewerRepository;
        }

        public async Task ExecuteAsync (Beer newBeer)
        {
            await _brewerRepository.AddBeer(newBeer);
        }

    }
}
