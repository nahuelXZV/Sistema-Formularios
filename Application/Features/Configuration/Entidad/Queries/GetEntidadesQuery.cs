using EntidadModel = Domain.Entities.Configuration.Entidad;
using AutoMapper;
using Domain.DTOs.Configuration;
using Domain.Interfaces.Shared;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Configuration.Entidad.Queries;

public class GetEntidadesQuery : ICommand<Response<List<EntidadDTO>>>
{
}

public class GetEntidadesHandler : ICommandHandler<GetEntidadesQuery, Response<List<EntidadDTO>>>
{
    private readonly IRepository<EntidadModel> _repository;
    private readonly IMapper _mapper;

    public GetEntidadesHandler(IRepository<EntidadModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<EntidadDTO>>> Handle(GetEntidadesQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query()
            .Where(e => !e.Eliminado);

        var entidades = await query.ToListAsync(cancellationToken);

        var entidadesDto = _mapper.Map<List<EntidadDTO>>(entidades);

        return new Response<List<EntidadDTO>>(entidadesDto);
    }
}
