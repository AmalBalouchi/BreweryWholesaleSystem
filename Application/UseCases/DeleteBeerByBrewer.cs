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

        public DeleteBeerByBrewer(IBeerRepository beerRepository) //Dependency injection of IBeerRepository
        {
            _beerRepository = beerRepository;
        }

        /*public async Task ExecuteAsync(int beerId)
        {
            var beer = await _beerRepository.GetByIdAsync(beerId);
            if (beer != null)
            {
                await _beerRepository.DeleteAsync(beer);
            }
        }*/
    }
}
