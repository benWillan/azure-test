using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherProject.Models;

namespace WeatherProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var fruits = new List<string>
        {
            "cherry",
            "strawberry",
            "banana",
            "avocado"
        };
        
        return View(fruits);
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