using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISalerRepository
    {
        Task<Saler> GetSalerByIdAsync(int id);
        Task UpdateSalerAsync(Saler saler);
        Task<Saler> GetSalerWithStock(int salerId);
    }

}
