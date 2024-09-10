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
        [ForeignKey("BrewerId")]
        public int BrewerId { get; set; } = 0;


        public Beer() { }
        public Beer(int id, string name, double alcohol, decimal price, int brewerId)
        {
            this.Id = id;
            this.Name = name;
            this.Alcohol = alcohol;
            this.Price = price;
            BrewerId = brewerId;
        }
    }

}
