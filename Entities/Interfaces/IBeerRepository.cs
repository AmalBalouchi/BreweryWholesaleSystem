using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBeerRepository
    {
        Task<Beer> GetBeerById(int beerId);
        Task AddBeerByBrewer(Beer beer, int brewerId);   
        Task DeleteBeerByBrewer(Beer beer, int brewerId); 
        Task<IEnumerable<Beer>> GetBeersByBrewer(int brewerId);
    }

}
