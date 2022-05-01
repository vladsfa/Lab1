using System;
using System.Collections.Generic;

namespace Lab1_asp.net
{
    public partial class Country
    {
        public Country()
        {
            CaseDiseases = new HashSet<CaseDisease>();
            People = new HashSet<Person>();
        }

        public string CountryName { get; set; } = null!;

        public virtual ICollection<CaseDisease> CaseDiseases { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
