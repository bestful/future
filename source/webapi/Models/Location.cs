using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Location
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }

        public virtual StockforProductinLocation Id1 { get; set; }
        public virtual SupplierinLocation Id2 { get; set; }
        public virtual RecipientinLocation IdNavigation { get; set; }
    }
}
