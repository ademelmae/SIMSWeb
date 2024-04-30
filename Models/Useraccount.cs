using System;
using System.Collections.Generic;

namespace SIMSWeb.Models
{
    public partial class Useraccount
    {
        public int UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Username { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
    }
}
