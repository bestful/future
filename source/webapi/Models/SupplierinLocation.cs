using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class SupplierinLocation
    {
        public int LocationId { get; set; }
        public int CompanyId { get; set; }

        public virtual CompanyforPerson CompanyforPerson { get; set; }
        public virtual Location Location { get; set; }
    }
}
