using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalerStock
    {
        // Foreign key from Saler entity
        public Guid SalerId { get; set; }

        [ForeignKey("SalerId")]
        public Saler Saler { get; set; }

        public Guid BeerId { get; set; }

        [ForeignKey("BeerId")]
        public Beer Beer { get; set; }
        public int Quantity { get; set; }
    }

}
