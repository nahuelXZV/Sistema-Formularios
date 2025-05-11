using RespuestaGrupoModel = Domain.Entities.Forms.RespuestaGrupo;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forms.RespuestaGrupo.Queries;

public class GetRespuestaGrupoByGestionIdQuery : ICommand<Response<List<RespuestaGrupoDTO>>>
{
    public required long GestionId { get; set; }
}

public class GetRespuestaGrupoByGestionIdHandler : ICommandHandler<GetRespuestaGrupoByGestionIdQuery, Response<List<RespuestaGrupoDTO>>>
{
    private readonly IRepository<RespuestaGrupoModel> _repository;
    private readonly IMapper _mapper;

    public GetRespuestaGrupoByGestionIdHandler(IRepository<RespuestaGrupoModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<RespuestaGrupoDTO>>> Handle(GetRespuestaGrupoByGestionIdQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query().Where(p => !p.Eliminado)
                            .Where(p => p.GestionId == request.GestionId)
                            .Include(p => p.Entidad)
                            .Include(p => p.Grupo);

        var respuesta = await query.ToListAsync();

        var listaDtos = _mapper.Map<List<RespuestaGrupoDTO>>(respuesta);

        return new Response<List<RespuestaGrupoDTO>>(listaDtos);
    }
}
