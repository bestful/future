using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class StockforProductinLocation
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
