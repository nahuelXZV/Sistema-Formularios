using GrupoModel = Domain.Entities.Forms.Grupo;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forms.Grupo.Queries;

public class GetGrupoByIdQuery : ICommand<Response<GrupoDTO>>
{
    public required long Id { get; set; }
}

public class GetGrupoByIdHandler : ICommandHandler<GetGrupoByIdQuery, Response<GrupoDTO>>
{
    private readonly IRepository<GrupoModel> _repository;
    private readonly IMapper _mapper;

    public GetGrupoByIdHandler(IRepository<GrupoModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<GrupoDTO>> Handle(GetGrupoByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query().Where(p => !p.Eliminado)
                            .Where(p => p.Id == request.Id)
                            .Include(p => p.ListaFormularios)
                            .ThenInclude(f => f.Formulario);

        var grupo = await query.FirstOrDefaultAsync();

        if (grupo == null) throw new Exception("Grupo no encontrado.");

        var dto = _mapper.Map<GrupoDTO>(grupo);
        return new Response<GrupoDTO>(dto);
    }
}
