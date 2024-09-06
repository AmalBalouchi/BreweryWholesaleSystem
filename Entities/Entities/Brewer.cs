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
        public ICollection<Beer> Beers { get; set; }
    }

}
