using Application.Features.Forms.RespuestaGrupo.Command;
using Application.Features.Forms.RespuestaGrupo.Queries;
using Domain.DTOs.Forms;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Forms;

public class RespuestaGrupoController : MainController
{
    private readonly ILogger<RespuestaGrupoController> _logger;

    public RespuestaGrupoController(ILogger<RespuestaGrupoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("ById/{idRespuesta}")]
    public async Task<IActionResult> GetById(long idRespuesta)
    {
        return Ok(await Mediator.Send(new GetRespuestaGrupoByIdQuery() { Id = idRespuesta }));
    }

    [HttpGet("ByGestion/{idGestion}")]
    public async Task<IActionResult> GetByGestion(long idGestion)
    {
        return Ok(await Mediator.Send(new GetRespuestaGrupoByGestionIdQuery() { GestionId = idGestion }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(RespuestaGrupoDTO respuesta)
    {
        return Ok(await Mediator.Send(new CreateRespuestaGrupoCommand { RespuestaGrupoDTO = respuesta }));
    }

    [HttpPut]
    public async Task<IActionResult> Update(RespuestaGrupoDTO respuesta)
    {
        return Ok(await Mediator.Send(new UpdateRespuestaGrupoCommand { RespuestaGrupoDTO = respuesta }));
    }

    [HttpDelete("Delete/{idRespuesta}")]
    public async Task<IActionResult> Delete(long idRespuesta)
    {
        return Ok(await Mediator.Send(new DeleteRespuestaGrupoCommand { Id = idRespuesta }));
    }
}
