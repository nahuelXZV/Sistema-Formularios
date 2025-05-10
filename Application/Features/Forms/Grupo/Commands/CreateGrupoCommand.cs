using GrupoModel = Domain.Entities.Forms.Grupo;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.Grupo.Commands;

public class CreateGrupoCommand : ICommand<Response<long>>
{
    public required GrupoDTO GrupoDTO { get; set; }
}

public class CreateGrupoHandler : ICommandHandler<CreateGrupoCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<GrupoModel> _repository;

    public CreateGrupoHandler(IMapper mapper, IRepository<GrupoModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(CreateGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupo = _mapper.Map<GrupoModel>(request.GrupoDTO);

        grupo = await _repository.AddAsync(grupo);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(grupo.Id);
    }
}