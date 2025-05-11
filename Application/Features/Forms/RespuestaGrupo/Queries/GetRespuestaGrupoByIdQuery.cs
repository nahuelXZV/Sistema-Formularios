using RespuestaGrupoModel = Domain.Entities.Forms.RespuestaGrupo;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces.Shared;
using Domain.DTOs.Forms;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forms.RespuestaGrupo.Queries;

public class GetRespuestaGrupoByIdQuery : ICommand<Response<RespuestaGrupoDTO>>
{
    public required long Id { get; set; }
}

public class GetRespuestaGrupoByIdHandler : ICommandHandler<GetRespuestaGrupoByIdQuery, Response<RespuestaGrupoDTO>>
{
    private readonly IRepository<RespuestaGrupoModel> _repository;
    private readonly IMapper _mapper;

    public GetRespuestaGrupoByIdHandler(IRepository<RespuestaGrupoModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<RespuestaGrupoDTO>> Handle(GetRespuestaGrupoByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query().Where(p => !p.Eliminado)
                            .Where(p => p.Id == request.Id)
                            .Include(p => p.Entidad)
                            .Include(p => p.Gestion);

        var respuesta = await query.FirstOrDefaultAsync();

        if (respuesta == null) throw new Exception("Grupo no encontrado.");

        var dto = _mapper.Map<RespuestaGrupoDTO>(respuesta);
        return new Response<RespuestaGrupoDTO>(dto);
    }
}
