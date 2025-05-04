using ConceptoModel = Domain.Entities.Configuration.Concepto;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Configuration;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Configuration.Concepto.Queries;

public class GetConceptoByTipoQuery : ICommand<Response<List<ConceptoDTO>>>
{
    public required int Tipo { get; set; }
}

public class GetConceptoByTipoHandler : ICommandHandler<GetConceptoByTipoQuery, Response<List<ConceptoDTO>>>>
{
    private readonly IRepository<ConceptoModel> _repository;
    private readonly IMapper _mapper;

    public GetConceptoByTipoHandler(IRepository<ConceptoModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<ConceptoDTO>>> Handle(GetConceptoByTipoQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query()
            .Where(e => e.Tipo == request.Tipo && !e.Eliminado);

        var listaConceptos = await query.ToListAsync(cancellationToken);

        var dto = _mapper.Map<List<ConceptoDTO>>(listaConceptos);
        return new Response<List<ConceptoDTO>>(dto);
    }
}
