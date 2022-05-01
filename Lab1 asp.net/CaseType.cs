using System;
using System.Collections.Generic;

namespace Lab1_asp.net
{
    public partial class CaseType
    {
        public CaseType()
        {
            CaseDiseases = new HashSet<CaseDisease>();
        }

        public string TypeNames { get; set; } = null!;

        public virtual ICollection<CaseDisease> CaseDiseases { get; set; }
    }
}
