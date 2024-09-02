using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public ICollection<SalerStock> WholesalerStocks { get; set; }
    }

}
