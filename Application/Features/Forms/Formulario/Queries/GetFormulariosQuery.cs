using FormularioModel = Domain.Entities.Forms.Formulario;
using AutoMapper;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Domain.DTOs.Shared;
using Domain.Extensions;

namespace Application.Features.Forms.Formulario.Queries;

public class GetFormulariosQuery : ICommand<Response<ResponseFilterDTO<FormularioDTO>>>
{
    public FilterDTO? Filter { get; set; }
}

public class GetFormulariosHandler : ICommandHandler<GetFormulariosQuery, Response<ResponseFilterDTO<FormularioDTO>>>
{
    private readonly IRepository<FormularioModel> _repository;
    private readonly IMapper _mapper;

    public GetFormulariosHandler(IRepository<FormularioModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<ResponseFilterDTO<FormularioDTO>>> Handle(GetFormulariosQuery request, CancellationToken cancellationToken)
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

        var formulariosDto = _mapper.Map<List<FormularioDTO>>(formularios);
        
        var response = new ResponseFilterDTO<FormularioDTO>
        {
            Data = formulariosDto,
            Total = total
        };

        return new Response<ResponseFilterDTO<FormularioDTO>>(response);
    }
}
