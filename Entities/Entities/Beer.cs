using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Beer
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public double Alcohol { get; set; } = 0;
        public decimal Price { get; set; } = 0;

        // Foreign keys from Brewer entity
        public int BrewerId { get; set; } = 0;

        [ForeignKey("BrewerId")]
        public Brewer Brewer { get; set; } = new Brewer();

        // Navigation property to a collection of salerStocks entity
        // A Beer can be sold by several Salers one to many relationship throught salerStocks
        public ICollection<SalerStock> salerStocks { get; set; }
        public Beer() { }
        public Beer(int id, string name, double alcohol, decimal price, int brewerId, Brewer brewer, ICollection<SalerStock> salerStocks)
        {
            this.Id = id;
            this.Name = name;
            this.Alcohol = alcohol;
            this.Price = price;
            BrewerId = brewerId;
            Brewer = brewer;
            this.salerStocks = salerStocks;
        }
    }

}
