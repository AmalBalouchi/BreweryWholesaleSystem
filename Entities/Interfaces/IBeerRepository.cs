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
        Task<Beer> GetBeerById(Guid beerId);
        Task AddBeerByBrewer(Beer beer, Guid brewerId);   
        Task DeleteBeerByBrewer(Beer beer, Guid brewerId); 
        Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId);
    }

}
