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
        public async Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId)
        {
            return await _context.Beers
                .Where(b => b.BrewerId.Equals( brewerId))
                .ToListAsync();
        }
    }
}
