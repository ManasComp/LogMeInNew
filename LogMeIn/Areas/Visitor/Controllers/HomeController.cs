﻿using System.Diagnostics;
using LogMeIn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LogMeIn.Areas.Visitor.Controllers;

[Area("Visitor")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}