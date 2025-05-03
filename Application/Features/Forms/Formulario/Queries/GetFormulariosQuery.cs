using FormularioModel = Domain.Entities.Forms.Formulario;
using AutoMapper;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forms.Formulario.Queries;

public class GetFormulariosQuery : ICommand<Response<List<FormularioDTO>>>
{
}

public class GetFormulariosHandler : ICommandHandler<GetFormulariosQuery, Response<List<FormularioDTO>>>
{
    private readonly IRepository<FormularioModel> _repository;
    private readonly IMapper _mapper;

    public GetFormulariosHandler(IRepository<FormularioModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<FormularioDTO>>> Handle(GetFormulariosQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _repository.Query().Where(p => !p.Eliminado);
        var formularios = await baseQuery.ToListAsync(cancellationToken);

        var formulariosDto = _mapper.Map<List<FormularioDTO>>(formularios);

        return new Response<List<FormularioDTO>>(formulariosDto);
    }
}
