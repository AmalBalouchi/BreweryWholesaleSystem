using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Saler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SalerStock> salerStocks { get; set; }
    }

}
