using System;
using System.Collections.Generic;

namespace SIMSWeb.Models
{
    public partial class Disciplinaryaction
    {
        public int Id { get; set; }
        public int ViolationId { get; set; }
        public string OffenseLevel { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
