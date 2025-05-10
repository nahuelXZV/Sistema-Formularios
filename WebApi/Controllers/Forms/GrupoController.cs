using Application.Features.Forms.Grupo.Commands;
using Application.Features.Forms.Grupo.Queries;
using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Forms;

public class GrupoController : MainController
{
    private readonly ILogger<GrupoController> _logger;

    public GrupoController(ILogger<GrupoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FilterDTO? filter)
    {
        return Ok(await Mediator.Send(new GetGruposQuery() { Filter = filter }));
    }

    [HttpGet("{idGrupo}")]
    public async Task<IActionResult> GetById(long idGrupo)
    {
        return Ok(await Mediator.Send(new GetGrupoByIdQuery() { Id = idGrupo }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(GrupoDTO grupo)
    {
        return Ok(await Mediator.Send(new CreateGrupoCommand { GrupoDTO = grupo }));
    }

    [HttpPut]
    public async Task<IActionResult> Update(GrupoDTO grupo)
    {
        return Ok(await Mediator.Send(new UpdateGrupoCommand { GrupoDTO = grupo }));
    }

    [HttpDelete("Delete/{idGrupo}")]
    public async Task<IActionResult> Delete(long idGrupo)
    {
        return Ok(await Mediator.Send(new DeleteGrupoCommand { Id = idGrupo }));
    }
}
