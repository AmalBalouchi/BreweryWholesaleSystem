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
        Task<IEnumerable<Beer>> GetBeersByBrewer(Guid brewerId);  // Method to display all beers by its brewer
    }
}