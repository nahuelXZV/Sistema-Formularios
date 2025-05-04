using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using WebClient.Extensions;
using WebClient.Models;
using WebClient.Services;
using WebClient.Models.Configuration;
using Domain.DTOs.Configuration;

namespace WebClient.Controllers;

public class EntidadController : MainController
{
    private readonly ILogger<EntidadController> _logger;

    public EntidadController(ViewModelFactory viewModelFactory, ILogger<EntidadController> logger, IAppServices appServices)
        : base(viewModelFactory, appServices)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Listado()
    {
        var model = _viewModelFactory.Create<EntidadViewModel>();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string search = "", [FromQuery] int limit = 10, [FromQuery] int offset = 0)
    {
        try
        {
            var listaGestiones = await _appServices.EntidadService.GetAll(new FilterDTO()
            {
                Limit = limit,
                Offset = offset,
                Search = search
            });

            return Ok(listaGestiones);
        }
        catch
        {
            return Ok(new ResponseFilterDTO<EntidadDTO>() { Total = 0, Data = new() });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromForm] long id = 0)
    {
        var model = _viewModelFactory.Create<EntidadViewModel>();

        model.IncluirBlazorComponents = true;

        if (id != 0)
            model.Entidad = await _appServices.EntidadService.GetById(id);
        else
            model.Entidad = new();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar([FromForm] long id)
    {
        try
        {
            await _appServices.EntidadService.Delete(id);
            this.AddSuccessTempMessage("Sucursal eliminado correctamente");
        }
        catch (Exception ex)
        {
            this.AddTempMessage(ex);
        }
        return RedirectToAction("Listado");
    }
}
