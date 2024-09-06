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
        Task AddBeerByBrewer(Beer beer, Guid brewerId);  // Method that allows the brewer to add a beer
        Task DeleteBeerByBrewer(Guid beerId, Guid brewerId);  // Method that allows the brewer to delete a beer by beerId
        Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId);  // Method to display all beers by its brewer
    }

}
