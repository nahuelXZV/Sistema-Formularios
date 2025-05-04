using ConceptoModel = Domain.Entities.Configuration.Concepto;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Configuration;
using Domain.Interfaces.Shared;

namespace Application.Features.Configuration.Concepto.Queries;

public class GetConceptoByIdQuery : ICommand<Response<ConceptoDTO>>
{
    public required long Id { get; set; }
}

public class GetConceptoByIdHandler : ICommandHandler<GetConceptoByIdQuery, Response<ConceptoDTO>>
{
    private readonly IRepository<ConceptoModel> _repository;
    private readonly IMapper _mapper;

    public GetConceptoByIdHandler(IRepository<ConceptoModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ConceptoDTO>> Handle(GetConceptoByIdQuery request, CancellationToken cancellationToken)
    {
        var entidad = await _repository.GetByIdAsync(request.Id);

        if (entidad == null || entidad.Eliminado) throw new Exception("Concepto no encontrada.");

        var dto = _mapper.Map<ConceptoDTO>(entidad);
        return new Response<ConceptoDTO>(dto);
    }
}
