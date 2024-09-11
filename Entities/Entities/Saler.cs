using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Domain.Entities
{
    public class Saler
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        // Navigation property to a collection of Beer entity
        // A saler sells a defined list of beers, it is a one to many relationship
        public ICollection<SalerStock> salerStocks { get; set; } = new List<SalerStock>();
    }

}
