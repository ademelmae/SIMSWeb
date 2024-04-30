using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIMSWeb.Models;

namespace SIMSWeb.Controllers
{
    [Route("api/count")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly simsdbContext _context;

        public CountController(simsdbContext context)
        {
            _context = context;
        }

        [HttpGet("studentCount")]
        public IActionResult GetStudentCount()
        {
            int studentCount = _context.Students.Count();
            return Ok(studentCount);
        }

        [HttpGet("violationCount")]
        public IActionResult GetPendingViolationCount()
        {
            int pendingViolationCount = _context.Studentviolations.Count(v => v.Status == "pending");
            return Ok(pendingViolationCount);
        }

        [HttpGet("ongoingCount")]
        public IActionResult GetOngoingViolationCount()
        {
            int ongoingViolationCount = _context.Studentviolations.Count(v => v.Status == "ongoing");
            return Ok(ongoingViolationCount);
        }

        [HttpGet("approvedCount")]
        public IActionResult GetResolvedViolationCount()
        {
            int approvedViolationCount = _context.Studentviolations.Count(v => v.Status == "resolved");
            return Ok(approvedViolationCount);
        }

    }
}