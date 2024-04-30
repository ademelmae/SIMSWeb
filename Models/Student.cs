using System;
using System.Collections.Generic;

namespace SIMSWeb.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? Firstname { get; set; } = null!;
        public string? Middlename { get; set; } = null!;
        public string? Lastname { get; set; } = null!;
        public string? Birthdate { get; set; } = null!;
        public int? Age { get; set; }
        public string? Gender { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Province { get; set; } = null!;
        public string? City { get; set; } = null!;
        public string? Barangay { get; set; } = null!;
        public string? Street { get; set; } = null!;
        public int? Zip { get; set; }
        public string? StudentIdNum { get; set; } = null!;
        public string? Department { get; set; } = null!;
        public string? Course { get; set; } = null!;
        public string? ParentName { get; set; } = null!;
        public string? ParentEmail { get; set; } = null!;
        public string? ParentHome { get; set; } = null!;
        public string? ParentContact { get; set; } = null!;
        public string? YearLevel { get; set; } = null!;
        public string? AcademicYear { get; set; } = null!;
    }
}
