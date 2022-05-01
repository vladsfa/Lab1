using System;
using System.Collections.Generic;

namespace Lab1_asp.net
{
    public partial class CaseDisease
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string CaseType { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string LocalityName { get; set; } = null!;
        public DateTime CaseDate { get; set; }

        public virtual CaseType CaseTypeNavigation { get; set; } = null!;
        public virtual Country CountryNameNavigation { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}
