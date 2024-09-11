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
        Task<Saler> GetSalerByIdAsync(int salerId); // Method that allows to get the saler by saler Id with its saleStock list
        Task UpdateSalerAsync(Saler saler); // Method that allows to update the saler entity changes and save
    }

}
