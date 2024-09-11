using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBeerByBrewer(int brewerId, Beer beer)
        {
            // Verify that the brewer exists in the Brewers table by the brewerId
            var brewer = await _context.Brewers.FindAsync(brewerId);
            if (brewer == null)
                throw new KeyNotFoundException("Brewer not found");

            beer.BrewerId = brewerId;
            _context.Beers.Add(beer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBeerByBrewer(int beerId, int brewerId)
        {
            try
            {
                // Find the beer by the beerId and brewerId in the Beers table
                var beerToDelete = await _context.Beers
                .Where(b => b.Id == beerId && b.BrewerId == brewerId)
                .FirstOrDefaultAsync();

                if (beerToDelete == null)
                {
                    throw new KeyNotFoundException("Beer not found or does not belong to the brewer");
                }

                _context.Beers.Remove(beerToDelete);

                // Use await keyword to not save the changes
                // until the previous find beer FirstOrDefaultAsync await method is complete
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deletion: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewer(int brewerId)
        {
            // Get the Beers list linked to the brewerId
            return await _context.Beers
                .Where(b => b.BrewerId.Equals( brewerId))
                .ToListAsync();
        }
        public async Task<Beer> GetBeerByIdAsync(int beerId)
        {
            // Get the beer from Beers entity by the beerId
            return await _context.Beers.FirstOrDefaultAsync(b => b.Id == beerId);
        }

        public decimal GetBeerPriceById(int beerId)
        {
            // Get the price of a beer by the beerId
            return _context.Beers.FirstOrDefault(b => b.Id == beerId).Price;
        }

        public async Task<IEnumerable<Beer>> GetAllBeers()
        {
            // return the list of all the beers
            return await _context.Beers.ToListAsync();
        }
    }
}
