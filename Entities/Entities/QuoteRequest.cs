using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuoteRequest
    {
        public int Id { get; set; }
        [ForeignKey("SalerId")]
        public int SalerId { get; set; }
        [ForeignKey("BeerId")]
        // Collection to add to the order multiple beers with their quantities
        public ICollection<Order> order { get; set; } = new List<Order>();
    }

    // Nested class to represent the list of the beers requested by the client and each quantity
    public class Order
    {
        [ForeignKey("BeerId")]
        public int BeerId { get; set; }

        public int Quantity { get; set; }
    }
}
