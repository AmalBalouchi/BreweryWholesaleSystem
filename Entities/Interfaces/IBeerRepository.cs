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
        Task AddBeerByBrewer(int brewerId, Beer beer);  // Method that allows the brewer to add a beer
        Task DeleteBeerByBrewer(int beerId, int brewerId);  // Method that allows the brewer to delete a beer by beerId
        Task<IEnumerable<Beer>> GetBeersByBrewer(int brewerId);  // Method to display all beers by its brewer
        Task<Beer> GetBeerByIdAsync(int id);
        decimal GetBeerPriceById(int id);
    }

}
