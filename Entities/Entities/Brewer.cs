using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brewer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Navigation property to a collection of Beer entity
        // A Brewer brews one or several Beers one to many relationship 
        public ICollection<Beer> Beers { get; set; } 
    }

}
