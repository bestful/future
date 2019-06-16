using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public virtual StockforProductinLocation IdNavigation { get; set; }
    }
}
