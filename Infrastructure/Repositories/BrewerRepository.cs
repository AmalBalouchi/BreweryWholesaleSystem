using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BrewerRepository : IBrewerRepository
    {
        private readonly ApplicationDbContext _context;

        public BrewerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBeer(Beer beer)
        {
            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBeer(Guid beerId)
        {
            var beer = await _context.Beers.FindAsync(beerId);
            if (beer != null)
            {
                _context.Beers.Remove(beer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId)
        {
            return await _context.Beers
                .Where(b => b.BrewerId.Equals( brewerId))
                .ToListAsync();
        }
    }
}
