using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Services;

namespace WebClient.Controllers;

public class HomeController : MainController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ViewModelFactory viewModelFactory, ILogger<HomeController> logger, IAppServices services)
        : base(viewModelFactory, services)
    {
        _logger = logger;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var model = _viewModelFactory.Create<HomeViewModel>();
        model.IncluirBlazorComponents = true;
        model.ListaEmpresas = (await _appServices.EntidadService.GetAll(null)).Data;
        model.ListaGestiones = (await _appServices.GestionService.GetAll(null)).Data;
        model.ListaGrupos = (await _appServices.GrupoService.GetAll(null)).Data;
        return View(model);
    }

    public IActionResult SystemDesign()
    {
        var model = _viewModelFactory.Create<HomeViewModel>();
        model.IncluirBlazorComponents = true;
        return View(model);
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
