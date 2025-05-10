using GrupoModel = Domain.Entities.Forms.Grupo;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using Domain.DTOs.Shared;
using Domain.Extensions;

namespace Application.Features.Forms.Grupo.Queries;

public class GetGruposQuery : ICommand<Response<ResponseFilterDTO<GrupoDTO>>>
{
    public FilterDTO? Filter { get; set; }
}

public class GetGruposHandler : ICommandHandler<GetGruposQuery, Response<ResponseFilterDTO<GrupoDTO>>>
{
    private readonly IRepository<GrupoModel> _repository;
    private readonly IMapper _mapper;

    public GetGruposHandler(IRepository<GrupoModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ResponseFilterDTO<GrupoDTO>>> Handle(GetGruposQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _repository.Query().Where(p => !p.Eliminado)
                        .ApplyFilter(
                            request.Filter,
                            p => string.IsNullOrEmpty(request.Filter.Search)
                                 || p.Nombre.ToLower().Contains(request.Filter.Search.ToLower())
                                 || p.Descripcion.ToLower().Contains(request.Filter.Search.ToLower())
                        );

        var total = await baseQuery.CountAsync(cancellationToken);

        var formularios = await baseQuery.ToListAsync(cancellationToken);

        var formulariosDto = _mapper.Map<List<GrupoDTO>>(formularios);

        var response = new ResponseFilterDTO<GrupoDTO>
        {
            Data = formulariosDto,
            Total = total
        };

        return new Response<ResponseFilterDTO<GrupoDTO>>(response);
    }
}
