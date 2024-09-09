using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Domain.Entities
{
    public class Brewer
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        // Navigation property to a collection of Beer entity
        // A Brewer brews one or several Beers one to many relationship 
        public ICollection<Beer> Beers { get; set; } 
        public Brewer(int id, string name) { 
            this.Id = id;
            this.Name = name;
        }
        public Brewer() { }
    }

}
