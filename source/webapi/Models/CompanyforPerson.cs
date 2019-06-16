using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class CompanyforPerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }

        public virtual SupplierinLocation Id1 { get; set; }
        public virtual RecipientinLocation IdNavigation { get; set; }
        public virtual Person Person { get; set; }
    }
}
