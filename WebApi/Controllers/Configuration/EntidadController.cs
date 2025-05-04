using Application.Features.Configuration.Entidad.Commands;
using Application.Features.Configuration.Entidad.Queries;
using Domain.DTOs.Configuration;
using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Configuration;

public class EntidadController : MainController
{
    private readonly ILogger<EntidadController> _logger;

    public EntidadController(ILogger<EntidadController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FilterDTO? filter)
    {
        return Ok(await Mediator.Send(new GetEntidadesQuery() { Filter = filter }));
    }

    [HttpGet("{idEntidad}")]
    public async Task<IActionResult> GetById(long idEntidad)
    {
        return Ok(await Mediator.Send(new GetEntidadByIdQuery() { Id = idEntidad }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(EntidadDTO entidad)
    {
        return Ok(await Mediator.Send(new CreateEntidadCommand { EntidadDTO = entidad }));
    }

    [HttpPut]
    public async Task<IActionResult> Update(EntidadDTO entidad)
    {
        return Ok(await Mediator.Send(new UpdateEntidadCommand { EntidadDTO = entidad }));
    }

    [HttpDelete("Delete/{idEntidad}")]
    public async Task<IActionResult> Delete(long idEntidad)
    {
        return Ok(await Mediator.Send(new DeleteEntidadCommand { Id = idEntidad }));
    }
}
