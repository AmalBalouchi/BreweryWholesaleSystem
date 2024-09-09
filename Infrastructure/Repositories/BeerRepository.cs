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

        public async Task<Beer> GetBeerById(int beerId)
        {
            try
            {
                return await _context.Beers
                .Include(b => b.Brewer)
                .Include(b => b.salerStocks)
                .FirstOrDefaultAsync(b => b.Id.Equals(beerId));
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
        }


        public async Task AddBeerByBrewer(int brewerId, Beer beer)
        {
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
                var beerToDelete = await _context.Beers
                .Where(b => b.Id == beerId && b.BrewerId == brewerId)
                .FirstOrDefaultAsync();

                if (beerToDelete == null)
                {
                    throw new KeyNotFoundException("Beer not found or does not belong to the brewer");
                }

                _context.Beers.Remove(beerToDelete);
                 await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deletion: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewer(int brewerId)
        {
            return await _context.Beers
                .Where(b => b.BrewerId.Equals( brewerId))
                .Include(b => b.Brewer)
                .ToListAsync();
        }
    }
}
