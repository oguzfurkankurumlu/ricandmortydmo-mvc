using System.Diagnostics;
using DMO;
using Microsoft.AspNetCore.Mvc;
using ricandmorty_mvc.Models;
using DTO;
using ViewModel;

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
        RickAndMortyDTO result = _webApiService.GetAll();

        #region DTO-View Model Mapping
        var newReturnModel = new RickAndMortyViewModel()
        {
            Info = new InfoViewModel()
            {
                Count = result.Info.Count,
                Next = result.Info.Next,
                Pages = result.Info.Pages,
                Prev = result.Info.Prev,
            },


        };
        newReturnModel.Results = result.Results.Select(s => new DetailViewModel()
        {
            Gender = s.Gender,
            Id = s.Id,
            Image = s.Image,
            Name = s.Name,
            Type = s.Type,
            Status = s.Status,
            Species = s.Species,
            Location = new LocationViewModel()
            {
                Name = s.Location.Name
            }
        }).ToList();

        #endregion

        return View(newReturnModel);
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
