using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using WebClient.Extensions;
using WebClient.Models;
using WebClient.Services;
using WebClient.Models.Forms;
using Domain.DTOs.Forms;

namespace WebClient.Controllers;

public class GestionController : MainController
{
    private readonly ILogger<GestionController> _logger;

    public GestionController(ViewModelFactory viewModelFactory, ILogger<GestionController> logger, IAppServices appServices)
        : base(viewModelFactory, appServices)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Listado()
    {
        var model = _viewModelFactory.Create<GestionViewModel>();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string search = "", [FromQuery] int limit = 10, [FromQuery] int offset = 0)
    {
        try
        {
            var listaGestiones = await _appServices.GestionService.GetAll(new FilterDTO()
            {
                Limit = limit,
                Offset = offset,
                Search = search
            });

            return Ok(listaGestiones);
        }
        catch
        {
            return Ok(new ResponseFilterDTO<GestionDTO>() { Total = 0, Data = new() });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromForm] long id = 0)
    {
        var model = _viewModelFactory.Create<GestionViewModel>();

        model.IncluirBlazorComponents = true;

        if (id != 0)
            model.Gestion = await _appServices.GestionService.GetById(id);
        else
            model.Gestion = new();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar([FromForm] long id)
    {
        try
        {
            await _appServices.GestionService.Delete(id);
            this.AddSuccessTempMessage("Gestion eliminado correctamente");
        }
        catch (Exception ex)
        {
            this.AddTempMessage(ex);
        }
        return RedirectToAction("Listado");
    }
}
