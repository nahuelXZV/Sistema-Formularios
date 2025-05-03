using GestionModel = Domain.Entities.Forms.Gestion;
using AutoMapper;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forms.Gestion.Queries;

public class GetGestionesQuery : ICommand<Response<List<GestionDTO>>>
{
}

public class GetGestionesHandler : ICommandHandler<GetGestionesQuery, Response<List<GestionDTO>>>
{
    private readonly IRepository<GestionModel> _repository;
    private readonly IMapper _mapper;

    public GetGestionesHandler(IRepository<GestionModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<GestionDTO>>> Handle(GetGestionesQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _repository.Query().Where(p => !p.Eliminado);

        var gestiones = await baseQuery.ToListAsync(cancellationToken);

        var gestionesDto = _mapper.Map<List<GestionDTO>>(gestiones);

        return new Response<List<GestionDTO>>(gestionesDto);
    }
}
