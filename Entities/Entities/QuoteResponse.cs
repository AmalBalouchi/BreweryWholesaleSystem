using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuoteResponse
    {
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal TotalPriceAfterDiscount { get; set; }
    }
}
