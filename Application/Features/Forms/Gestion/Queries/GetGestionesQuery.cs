using GestionModel = Domain.Entities.Forms.Gestion;
using AutoMapper;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Domain.DTOs.Shared;
using Domain.Extensions;

namespace Application.Features.Forms.Gestion.Queries;

public class GetGestionesQuery : ICommand<Response<ResponseFilterDTO<GestionDTO>>>
{
    public FilterDTO? Filter { get; set; }
}

public class GetGestionesHandler : ICommandHandler<GetGestionesQuery, Response<ResponseFilterDTO<GestionDTO>>>
{
    private readonly IRepository<GestionModel> _repository;
    private readonly IMapper _mapper;

    public GetGestionesHandler(IRepository<GestionModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ResponseFilterDTO<GestionDTO>>> Handle(GetGestionesQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _repository.Query().Where(p => !p.Eliminado)
                        .ApplyFilter(request.Filter,
                                        p => string.IsNullOrEmpty(request.Filter.Search)
                                             || p.Nombre.ToLower().Contains(request.Filter.Search.ToLower())
                                             || p.Descripcion.ToLower().Contains(request.Filter.Search.ToLower())
                        );
        var total = await baseQuery.CountAsync(cancellationToken);


        var gestiones = await baseQuery.ToListAsync(cancellationToken);

        var gestionesDto = _mapper.Map<List<GestionDTO>>(gestiones);

        var response = new ResponseFilterDTO<GestionDTO>
        {
            Data = gestionesDto,
            Total = total
        };

        return new Response<ResponseFilterDTO<GestionDTO>>(response);
    }
}
