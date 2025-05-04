using Application.Features.Configuration.Concepto.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Configuration;

public class ConceptoController : MainController
{
    private readonly ILogger<ConceptoController> _logger;

    public ConceptoController(ILogger<ConceptoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("ById/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await Mediator.Send(new GetConceptoByIdQuery() { Id = id }));
    }

    [HttpGet("ByTipo/{tipo}")]
    public async Task<IActionResult> GetById(int tipo)
    {
        return Ok(await Mediator.Send(new GetConceptoByTipoQuery() { Tipo = tipo }));
    }
}
