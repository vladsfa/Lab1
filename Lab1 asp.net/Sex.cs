using System;
using System.Collections.Generic;

namespace Lab1_asp.net
{
    public partial class Sex
    {
        public Sex()
        {
            People = new HashSet<Person>();
        }

        public string SexName { get; set; } = null!;

        public virtual ICollection<Person> People { get; set; }
    }
}
