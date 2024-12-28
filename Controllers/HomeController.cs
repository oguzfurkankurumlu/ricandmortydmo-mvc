using System.Diagnostics;
using DMO;
using Microsoft.AspNetCore.Mvc;
using ricandmorty_mvc.Models;

namespace ricandmorty_mvc.Controllers;

public class HomeController : Controller
{
    public IWebApiService _webApiService { get; set; }
    public HomeController(IWebApiService webApiService)
    {
        _webApiService = webApiService;
    }

    public IActionResult Index()
    {
        RickAndMortyDMO result = _webApiService.GetAll();
        return View(result);
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
