using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Data;

public class SalerRepository : ISalerRepository
{
    private readonly ApplicationDbContext _context;

    public SalerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Saler> GetSalerByIdAsync(int id)
    {
        return await _context.Salers.Include(s => s.salerStocks).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task UpdateSalerAsync(Saler saler)
    {
        _context.Salers.Update(saler);
        await _context.SaveChangesAsync();
    }
}
