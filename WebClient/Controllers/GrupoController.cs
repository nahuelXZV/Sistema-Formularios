using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;
using WebClient.Extensions;
using WebClient.Models.Forms;
using WebClient.Models;
using WebClient.Services;

namespace WebClient.Controllers;

public class GrupoController : MainController
{
    private readonly ILogger<GrupoController> _logger;

    public GrupoController(ViewModelFactory viewModelFactory, ILogger<GrupoController> logger, IAppServices appServices)
        : base(viewModelFactory, appServices)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Listado()
    {
        var model = _viewModelFactory.Create<GrupoViewModel>();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string search = "", [FromQuery] int limit = 10, [FromQuery] int offset = 0)
    {
        try
        {
            var listaGrupos = await _appServices.GrupoService.GetAll(new FilterDTO()
            {
                Limit = limit,
                Offset = offset,
                Search = search
            });

            return Ok(listaGrupos);
        }
        catch
        {
            return Ok(new ResponseFilterDTO<GrupoDTO>() { Total = 0, Data = new() });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromForm] long id = 0)
    {
        var model = _viewModelFactory.Create<GrupoViewModel>();

        model.IncluirBlazorComponents = true;
        model.ListaFormularios = (await _appServices.FormularioService.GetAll(null)).Data;

        if (id != 0)
            model.Grupo = await _appServices.GrupoService.GetById(id);
        else
            model.Grupo = new();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar([FromForm] long id)
    {
        try
        {
            await _appServices.GrupoService.Delete(id);
            this.AddSuccessTempMessage("Grupo eliminado correctamente");
        }
        catch (Exception ex)
        {
            this.AddTempMessage(ex);
        }
        return RedirectToAction("Listado");
    }
}