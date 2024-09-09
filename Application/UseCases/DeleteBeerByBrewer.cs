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

        public async Task ExecuteAsync(int beerId, int brewerId)
        {
            try
            {
                await _beerRepository.DeleteBeerByBrewer(beerId, brewerId);
                Console.WriteLine("Beer deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deletion: {ex.Message}");
                throw;
            }
        }

    }
}
