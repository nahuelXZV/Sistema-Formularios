using FormularioModel = Domain.Entities.Forms.Formulario;
using AutoMapper;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Domain.Common;

namespace Application.Features.Forms.Formulario.Queries;

public class GetFormularioByIdQuery : ICommand<Response<FormularioDTO>>
{
    public required long Id { get; set; }
}

public class GetFormularioByIdHandler : ICommandHandler<GetFormularioByIdQuery, Response<FormularioDTO>>
{
    private readonly IRepository<FormularioModel> _repository;
    private readonly IMapper _mapper;

    public GetFormularioByIdHandler(IRepository<FormularioModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<FormularioDTO>> Handle(GetFormularioByIdQuery request, CancellationToken cancellationToken)
    {
        var formulario = await _repository.GetByIdAsync(request.Id);

        if (formulario == null || formulario.Eliminado) throw new Exception("Formulario no encontrado.");

        var dto = _mapper.Map<FormularioDTO>(formulario);
        return new Response<FormularioDTO>(dto);
    }
}
