using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMSWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace SIMSWeb.Controllers
{
    [EnableCors]
    [Route("/api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly simsdbContext _context;

        public AuthController(simsdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Student>> getstudentdetails()
        {
            return _context.Students.ToList();
        }

        [HttpGet]
        public IActionResult Login(string studentIdNum, string password)
        {
            Console.WriteLine($"Received data - StudentIdNum: {studentIdNum}, Password: {password}");
            var student = _context.Students
                .FirstOrDefault(s => s.StudentIdNum == studentIdNum);

            if (student == null || student.Password != password)
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            // TODO: You may want to return a token for secure communication
            return Ok(new { message = "Login successful", studentIdNum = student.StudentIdNum });
        }



    }












}