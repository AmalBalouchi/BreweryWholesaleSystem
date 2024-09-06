using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBrewerRepository
    {
        Task AddBeer(Beer beer);  // Method that allows the brewer to add a beer
        Task DeleteBeer(Guid beerId);  // Method that allows the brewer to delete a beer by beerId
        Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId);  // Method to display all beers by its brewer
    }
}