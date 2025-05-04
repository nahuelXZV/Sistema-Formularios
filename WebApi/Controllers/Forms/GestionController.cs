using Application.Features.Forms.Formulario.Commands;
using Application.Features.Forms.Gestion.Commands;
using Application.Features.Forms.Gestion.Queries;
using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Forms;

public class GestionController : MainController
{
    private readonly ILogger<GestionController> _logger;

    public GestionController(ILogger<GestionController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FilterDTO? filter)
    {
        return Ok(await Mediator.Send(new GetGestionesQuery() { Filter = filter }));
    }

    [HttpGet("activa")]
    public async Task<IActionResult> GetActive(long idGestion)
    {
        return Ok(await Mediator.Send(new GetGestionActivaQuery() { }));
    }

    [HttpGet("{idGestion}")]
    public async Task<IActionResult> GetById(long idGestion)
    {
        return Ok(await Mediator.Send(new GetGestionByIdQuery() { Id = idGestion }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(GestionDTO gestion)
    {
        return Ok(await Mediator.Send(new CreateGestionCommand { GestionDTO = gestion }));
    }

    [HttpPut]
    public async Task<IActionResult> Update(GestionDTO gestion)
    {
        return Ok(await Mediator.Send(new UpdateGestionCommand { GestionDTO = gestion }));
    }

    [HttpDelete("Delete/{idGestion}")]
    public async Task<IActionResult> Delete(long idGestion)
    {
        return Ok(await Mediator.Send(new DeleteGestionCommand { Id = idGestion }));
    }
}