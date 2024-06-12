using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMSWeb.Models;

namespace SIMSWeb.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class ViolationController : ControllerBase
    {
        private readonly simsdbContext _context;

        public ViolationController(simsdbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostViolation([FromBody] Studentviolation studentViolation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Studentviolations.Add(studentViolation);
            _context.SaveChanges();

            return Ok();
        }

          [HttpPut("updateviolation/{id}")]
        public async Task<IActionResult> UpdateViolation(int id, [FromBody] Studentviolation updatedData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingViolation = await _context.Studentviolations.FindAsync(id);

                if (existingViolation == null)
                {
                    return NotFound();
                }


                existingViolation.OffenseLevel = updatedData.OffenseLevel;
                existingViolation.ViolationType = updatedData.ViolationType;
                existingViolation.ViolationDate = updatedData.ViolationDate;
                existingViolation.ViolationTime = updatedData.ViolationTime;
                existingViolation.DisciplinaryAction = updatedData.DisciplinaryAction;
                existingViolation.OffenseType = updatedData.OffenseType;
                existingViolation.Location = updatedData.Location;
                existingViolation.ReportingName = updatedData.ReportingName;
                existingViolation.ReportingRole = updatedData.ReportingRole;
                existingViolation.ReportingContact = updatedData.ReportingContact;
                existingViolation.Description = updatedData.Description;
                existingViolation.Status = updatedData.Status;

                // Save changes to the database
                await _context.SaveChangesAsync();

                return Ok(new { message = "Violation updated successfully" });
            }
            catch
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, new { error = "An error occurred while updating the violation" });
            }
        }

        [HttpGet("getViolations")]
        public IActionResult GetViolations()
        {
            var violations = _context.Studentviolations.ToList();
            return Ok(violations);
        }

        [HttpGet("getViolations")]
        public IActionResult GetViolations(string studentIdNum)
        {
            // Assuming 'ViolationType' is a property in your Studentviolation model
            var violations = _context.Studentviolations
                .Where(v => v.StudentIdNum == studentIdNum)
                .Select(v => new
                {
                    ViolationType = v.ViolationType,
                    Data = v
                })
                .ToList();

            return Ok(violations);
        }
        [HttpGet("getViolationsTable")]
        public async Task<ActionResult<IEnumerable<object>>> GetViolationsTable()
        {
            // Projecting only the required fields
            var result = await _context.Studentviolations
                .Select(s => new
                {
                    s.ViolationId,
                    s.StudentName,
                    s.StudentIdNum,
                    s.Course,
                    s.AcademicYear,
                    s.OffenseLevel,
                    s.ViolationType,
                    s.Status
                })
                .ToListAsync();

            return result;
        }


        [HttpDelete("deleteViolation/{id}")]
        public async Task<IActionResult> DeleteViolation(int id)
        {
            try
            {
                var violation = await _context.Studentviolations.FindAsync(id);

                if (violation == null)
                {
                    return NotFound();
                }

                _context.Studentviolations.Remove(violation);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Violation deleted successfully" });
            }
            catch
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, new { error = "An error occurred while deleting the violation" });
            }
        }

        [HttpGet("{violationId}")]
        public ActionResult<Studentviolation> GetViolation(int violationId)
        {
            var violation = _context.Studentviolations.FirstOrDefault(v => v.ViolationId == violationId);

            if (violation == null)
            {
                return NotFound();
            }

            return Ok(violation);
        }



        [HttpGet("GetMonthlyReports")]
        public IActionResult GetMonthlyReports(int year, int month)
        {
            // Retrieve all records from the database
            var allReports = _context.Studentviolations.ToList();

            // Filter records in-memory
            var reports = allReports
                .Where(report =>
                {
                    DateTime date;
                    return DateTime.TryParse(report.ViolationDate, out date) &&
                           date.Year == year &&
                           date.Month == month;
                })
                .ToList();

            return Ok(reports);
        }


        [HttpGet("getViolationDetails")]
        public async Task<ActionResult<Studentviolation>> getViolationDetails(int violationId)
        {
            var violation = await _context.Studentviolations.FirstOrDefaultAsync(s => s.ViolationId == violationId);

            if (violation == null)
            {
                return NotFound();
            }

            return Ok(violation);
        }

        [HttpPost("createviolation")]
        public async Task<IActionResult> CreateViolation([FromForm] Violation violation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Violations.Add(violation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViolation", new { id = violation.Id }, violation);
        }

        [HttpGet("getAllViolations")]
        public IActionResult GetAllViolations()
        {
            var violations = _context.Violations.ToList();
            return Ok(violations);
        }
    }

}
