using GestionModel = Domain.Entities.Forms.Gestion;
using AutoMapper;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;
using Domain.Common;

namespace Application.Features.Forms.Gestion.Queries;

public class GetGestionByIdQuery : ICommand<Response<GestionDTO>>
{
    public required long Id { get; set; }
} 

public class GetGestionByIdHandler : ICommandHandler<GetGestionByIdQuery, Response<GestionDTO>>
{
    private readonly IRepository<GestionModel> _repository;
    private readonly IMapper _mapper;

    public GetGestionByIdHandler(IRepository<GestionModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<GestionDTO>> Handle(GetGestionByIdQuery request, CancellationToken cancellationToken)
    {
        var gestion = await _repository.GetByIdAsync(request.Id);

        if (gestion == null || gestion.Eliminado)
        {
            throw new Exception("Gestion no encontrado.");
        }

        var dto = _mapper.Map<GestionDTO>(gestion);
        return new Response<GestionDTO>(dto);
    }
}
