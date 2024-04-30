using System;
using System.Collections.Generic;

namespace SIMSWeb.Models
{
    public partial class Violation
    {
        public int Id { get; set; }
        public string ViolationName { get; set; } = null!;
    }
}
