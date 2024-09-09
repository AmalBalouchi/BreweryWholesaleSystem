using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Domain.Entities
{
    public class SalerStock
    {
        // Foreign key from Saler entity
        public int SalerId { get; set; } = 0;

        [ForeignKey("SalerId")]
        public Saler Saler { get; set; } = new Saler();

        public int BeerId { get; set; } = 0;

        [ForeignKey("BeerId")]
        public Beer Beer { get; set; } = new Beer();
        public int Quantity { get; set; } = 0;
    }

}
