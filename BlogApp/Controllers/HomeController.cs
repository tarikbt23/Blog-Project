using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger; // hata ve bilgi loglama için kullanılıyor

    public HomeController(ILogger<HomeController> logger) // constructora dependency injection yapılıyor
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(); // Views/Home/Index.chtml dosyası dönecek
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
