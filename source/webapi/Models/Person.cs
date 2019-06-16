using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Password { get; set; }

        public virtual ContactforPerson Id1 { get; set; }
        public virtual CompanyforPerson IdNavigation { get; set; }
    }
}
