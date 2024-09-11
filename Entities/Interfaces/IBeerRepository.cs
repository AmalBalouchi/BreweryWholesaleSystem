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
        Task<Beer> GetBeerByIdAsync(int beerId); // Method that allows to get a beer for the beerId
        Task AddBeerByBrewer(int brewerId, Beer beer);  // Method that allows the brewer to add a beer
        Task DeleteBeerByBrewer(int beerId, int brewerId);  // Method that allows the brewer to delete a beer by beerId
        Task<IEnumerable<Beer>> GetBeersByBrewer(int brewerId);  // Method to display all beers by the brewerId
        decimal GetBeerPriceById(int beerId); // Method that allows to get the beer price by its Id 
        Task<IEnumerable<Beer>> GetAllBeers(); // Method that allows to display all beers grouped by BrewerIds
    }

}
