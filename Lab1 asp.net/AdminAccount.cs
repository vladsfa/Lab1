using System;
using System.Collections.Generic;

namespace Lab1_asp.net
{
    public partial class AdminAccount
    {
        public int Id { get; set; }
        public string LoginAccount { get; set; } = null!;
        public string PasswordAccount { get; set; } = null!;
    }
}
