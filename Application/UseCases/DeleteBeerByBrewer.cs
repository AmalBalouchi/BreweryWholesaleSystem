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
        private readonly IBeerRepository _beerRepository;

        public DeleteBeerByBrewer(IBeerRepository beerRepository) //Dependency injection of IBrewerRepository
        {
            _beerRepository = beerRepository;
        }

        public void ExecuteAsync(Guid beerId, Guid brewerId)
        {
            _beerRepository.DeleteBeerByBrewer(beerId, brewerId);
        }
    }
}
