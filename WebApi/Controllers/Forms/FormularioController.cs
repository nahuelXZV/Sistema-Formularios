using Application.Features.Forms.Formulario.Commands;
using Application.Features.Forms.Formulario.Queries;
using Domain.DTOs.Forms;
using Domain.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Forms;

public class FormularioController : MainController
{
    private readonly ILogger<FormularioController> _logger;

    public FormularioController(ILogger<FormularioController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FilterDTO? filter)
    {
        return Ok(await Mediator.Send(new GetFormulariosQuery() { Filter = filter }));
    }

    [HttpGet("{idFormulario}")]
    public async Task<IActionResult> GetById(long idFormulario)
    {
        return Ok(await Mediator.Send(new GetFormularioByIdQuery() { Id = idFormulario }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(FormularioDTO formulario)
    {
        return Ok(await Mediator.Send(new CreateFormularioCommand { FormularioDTO = formulario }));
    }

    [HttpPut]
    public async Task<IActionResult> Update(FormularioDTO formulario)
    {
        return Ok(await Mediator.Send(new UpdateFormularioCommand { FormularioDTO = formulario }));
    }

    [HttpDelete("Delete/{idFormulario}")]
    public async Task<IActionResult> Delete(long idFormulario)
    {
        return Ok(await Mediator.Send(new DeleteFormularioCommand { Id = idFormulario }));
    }
}
