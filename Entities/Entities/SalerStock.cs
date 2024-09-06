using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalerStock
    {
        public Guid Id { get; set; }
        public int SalerId { get; set; }
        public Saler Saler { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int Quantity { get; set; }
    }

}
