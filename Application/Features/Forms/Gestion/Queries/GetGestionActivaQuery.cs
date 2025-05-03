using GestionModel = Domain.Entities.Forms.Gestion;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forms.Gestion.Queries;

public class GetGestionActivaQuery : ICommand<Response<GestionDTO>>
{
}

public class GetGestionActivaHandler : ICommandHandler<GetGestionActivaQuery, Response<GestionDTO>>
{
    private readonly IRepository<GestionModel> _repository;
    private readonly IMapper _mapper;

    public GetGestionActivaHandler(IRepository<GestionModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<GestionDTO>> Handle(GetGestionActivaQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.Query()
            .Where(p => !p.Eliminado)
            .Where(p => p.Activo);

        var gestion = await query.FirstOrDefaultAsync(cancellationToken);

        if (gestion == null || gestion.Eliminado) throw new Exception("Gestion no encontrado.");

        var dto = _mapper.Map<GestionDTO>(gestion);
        return new Response<GestionDTO>(dto);
    }
}
