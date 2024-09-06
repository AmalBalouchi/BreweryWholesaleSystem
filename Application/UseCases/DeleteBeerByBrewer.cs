using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class DeleteBeerByBrewer
    {
        private readonly IBrewerRepository _brewerRepository;
        private readonly IBeerRepository _beerRepository;

        public DeleteBeerByBrewer(IBrewerRepository brewerRepository, IBeerRepository beerRepository) //Dependency injection of IBrewerRepository
        {
            _brewerRepository = brewerRepository;
            _beerRepository = beerRepository;
        }

        public void Execute(int beerId)
        {
            var beer = _beerRepository.GetBeerById(beerId);
            if (beer != null)
            {
                _brewerRepository.DeleteBeer(beerId);
            }
        }
    }
}
