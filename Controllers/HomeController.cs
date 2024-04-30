﻿using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMSWeb.Models;

namespace SIMSWeb.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }
    public IActionResult dashboards()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult Violation()
    {
        return View();
    }

     public IActionResult ViewViolationInfo()
    {
        return View();
    }
     public IActionResult StudentLists()
    {
        return View();
    }
   
    public IActionResult RegisterStudent()
    {
        return View();
    }

    public IActionResult SearchStudent()
    {
        return View();
    }

    public IActionResult Reports()
    {
        return View();
    }

    public IActionResult ViewViolations()
    {
        return View();
    }
    public IActionResult UpdateStudent()
    {
        return View();
    }

    public IActionResult ViewStudentInfo()
    {
        return View();
    }

     public IActionResult UpdateViolation()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
