using EntidadModel = Domain.Entities.Configuration.Entidad;
using AutoMapper;
using Domain.DTOs.Configuration;
using Domain.Interfaces.Shared;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Domain.DTOs.Shared;
using Domain.Extensions;

namespace Application.Features.Configuration.Entidad.Queries;

public class GetEntidadesQuery : ICommand<Response<ResponseFilterDTO<EntidadDTO>>>
{
    public FilterDTO? Filter { get; set; }
}

public class GetEntidadesHandler : ICommandHandler<GetEntidadesQuery, Response<ResponseFilterDTO<EntidadDTO>>>
{
    private readonly IRepository<EntidadModel> _repository;
    private readonly IMapper _mapper;

    public GetEntidadesHandler(IRepository<EntidadModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ResponseFilterDTO<EntidadDTO>>> Handle(GetEntidadesQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query()
            .Where(e => !e.Eliminado)
            .ApplyFilter(
                request.Filter,
                p => string.IsNullOrEmpty(request.Filter.Search)
                     || p.Nombre.ToLower().Contains(request.Filter.Search.ToLower())
                     || p.Descripcion.ToLower().Contains(request.Filter.Search.ToLower())
            );
        var total = await query.CountAsync(cancellationToken);

        var entidades = await query.ToListAsync(cancellationToken);
        var entidadesDto = _mapper.Map<List<EntidadDTO>>(entidades);

        var response = new ResponseFilterDTO<EntidadDTO>
        {
            Data = entidadesDto,
            Total = total
        };

        return new Response<ResponseFilterDTO<EntidadDTO>>(response);
    }
}
