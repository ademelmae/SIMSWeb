using System;
using System.Collections.Generic;

namespace SIMSWeb.Models
{
    public partial class Studentviolation
    {
        public int ViolationId { get; set; }
        public string? StudentName { get; set; } = null!;
        public string? StudentIdNum { get; set; } = null!;
        public string? Course { get; set; } = null!;
        public string? AcademicYear { get; set; } = null!;
        public string? ViolationType { get; set; } = null!;
        public string? ViolationDate { get; set; } = null!;
        public string? ViolationTime { get; set; } = null!;
        public string? OffenseLevel { get; set; } = null!;
        public string? DisciplinaryAction { get; set; } = null!;
        public string? OffenseType { get; set; } = null!;
        public string? Location { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? ReportingName { get; set; } = null!;
        public string? ReportingRole { get; set; } = null!;
        public string? ReportingContact { get; set; } = null!;
        public string? Status { get; set; } = null!;
    }
}
