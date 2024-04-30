using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMSWeb.Models;

namespace SIMSWeb.Controllers
{
    [Route("api/disciplinaryactions")]
    [ApiController]
    public class DisciplinaryActionsController : ControllerBase
    {
        private readonly simsdbContext _context;

        public DisciplinaryActionsController(simsdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetByOffenseLevel(string offenselevel, int violationId)
        {
            var actions = await _context.Disciplinaryactions
                .Where(d => d.OffenseLevel == offenselevel && d.ViolationId == violationId)
                .Select(d => d.Description)
                .ToListAsync();
            return Ok(actions);
        }




    }
}
