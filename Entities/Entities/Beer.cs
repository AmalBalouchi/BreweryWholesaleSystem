using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Alcohol { get; set; }
        public decimal Price { get; set; }
        public int BrewerId { get; set; }
        public Brewer Brewer { get; set; }
        public ICollection<SalerStock> salerStocks { get; set; }
    }

}
