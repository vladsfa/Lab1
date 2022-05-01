using System;
using System.Collections.Generic;

namespace Lab1_asp.net
{
    public partial class Person
    {
        public Person()
        {
            CaseDiseases = new HashSet<CaseDisease>();
        }

        public int Id { get; set; }
        public string SexName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string LocalityName { get; set; } = null!;
        public DateTime BirthdayDate { get; set; }
        public string PersonName { get; set; } = null!;
        public string PersonSurname { get; set; } = null!;

        public virtual Country CountryNameNavigation { get; set; } = null!;
        public virtual Sex SexNameNavigation { get; set; } = null!;
        public virtual ICollection<CaseDisease> CaseDiseases { get; set; }
    }
}
