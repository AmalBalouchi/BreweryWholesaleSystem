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
        // Get the saler by the salerId from Saler table with its salerStocks
        return await _context.Salers.Include(s => s.salerStocks).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task UpdateSalerAsync(Saler saler)
    {
        // Update the changes performed to the saler entity and save the changes into DB context
        _context.Salers.Update(saler);
        await _context.SaveChangesAsync();
    }
}
