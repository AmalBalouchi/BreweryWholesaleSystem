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
    }
}
