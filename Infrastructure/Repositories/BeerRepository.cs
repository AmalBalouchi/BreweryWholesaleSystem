using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Beer> GetBeerByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            else { 
            return await _context.Beers
                .Include(b => b.Brewer)
                .Include(b => b.salerStocks)
                .FirstOrDefaultAsync(b => b.Name == name);
            }
        }


        public async Task AddBeerByBrewer(Beer beer, int brewerId)
        {
            var brewer = await _context.Brewers.FindAsync(brewerId);
            if (brewer == null)
                throw new KeyNotFoundException("Brewer not found");

            beer.BrewerId = brewerId;
            _context.Beers.Add(beer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBeerByBrewer(Beer beer, int brewerId)
        {
            var beerToDelete = await _context.Beers
                .FirstOrDefaultAsync(b => b.Id == beer.Id && b.BrewerId == brewerId);

            if (beerToDelete == null)
                throw new KeyNotFoundException("Beer not found or does not belong to the brewer");

            _context.Beers.Remove(beerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewer(int brewerId)
        {
            return await _context.Beers
                .Where(b => b.BrewerId == brewerId)
                .Include(b => b.Brewer)
                .ToListAsync();
        }
    }
}
