using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class ContactforPerson
    {
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Person Person { get; set; }
    }
}
