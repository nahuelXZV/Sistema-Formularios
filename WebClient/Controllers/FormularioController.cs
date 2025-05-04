using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using WebClient.Extensions;
using WebClient.Models.Forms;
using WebClient.Models;
using WebClient.Services;
using Domain.Constants;

namespace WebClient.Controllers;

public class FormularioController : MainController
{
    private readonly ILogger<FormularioController> _logger;

    public FormularioController(ViewModelFactory viewModelFactory, ILogger<FormularioController> logger, IAppServices appServices)
        : base(viewModelFactory, appServices)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Listado()
    {
        var model = _viewModelFactory.Create<FormularioViewModel>();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string search = "", [FromQuery] int limit = 10, [FromQuery] int offset = 0)
    {
        try
        {
            var listaGestiones = await _appServices.FormularioService.GetAll(new FilterDTO()
            {
                Limit = limit,
                Offset = offset,
                Search = search
            });

            return Ok(listaGestiones);
        }
        catch
        {
            return Ok(new ResponseFilterDTO<FormularioDTO>() { Total = 0, Data = new() });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromForm] long id = 0)
    {
        var model = _viewModelFactory.Create<FormularioViewModel>();

        model.IncluirBlazorComponents = true;

        if (id != 0)
            model.Formulario = await _appServices.FormularioService.GetById(id);
        else
            model.Formulario = new();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar([FromForm] long id)
    {
        try
        {
            await _appServices.FormularioService.Delete(id);
            this.AddSuccessTempMessage("Formulario eliminado correctamente");
        }
        catch (Exception ex)
        {
            this.AddTempMessage(ex);
        }
        return RedirectToAction("Listado");
    }
}
