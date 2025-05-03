using EntidadModel = Domain.Entities.Configuration.Entidad;
using AutoMapper;
using Domain.DTOs.Configuration;
using Domain.Interfaces.Shared;
using Domain.Common;

namespace Application.Features.Configuration.Entidad.Queries;

public class GetEntidadByIdQuery : ICommand<Response<EntidadDTO>>
{
    public required long Id { get; set; }
}

public class GetEntidadByIdHandler : ICommandHandler<GetEntidadByIdQuery, Response<EntidadDTO>>
{
    private readonly IRepository<EntidadModel> _repository;
    private readonly IMapper _mapper;

    public GetEntidadByIdHandler(IRepository<EntidadModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<EntidadDTO>> Handle(GetEntidadByIdQuery request, CancellationToken cancellationToken)
    {
        var entidad = await _repository.GetByIdAsync(request.Id);

        if (entidad == null || entidad.Eliminado) throw new Exception("Entidad no encontrada.");

        var dto = _mapper.Map<EntidadDTO>(entidad);
        return new Response<EntidadDTO>(dto);
    }
}
