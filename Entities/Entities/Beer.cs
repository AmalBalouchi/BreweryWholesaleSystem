using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // Foreign keys from Brewer entity
        public Guid BrewerId { get; set; }

        [ForeignKey("BrewerId")]
        public Brewer Brewer { get; set; }

        // Navigation property to a collection of salerStocks entity
        // A Beer can be sold by several Salers one to many relationship throught salerStocks
        public ICollection<SalerStock> salerStocks { get; set; }
    }

}
