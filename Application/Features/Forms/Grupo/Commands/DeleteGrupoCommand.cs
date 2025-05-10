using GrupoModel = Domain.Entities.Forms.Grupo;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.Grupo.Commands;

public class DeleteGrupoCommand : ICommand<Response<bool>>
{
    public required long Id { get; set; }
}

public class DeleteGrupoHandler : ICommandHandler<DeleteGrupoCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<GrupoModel> _repository;

    public DeleteGrupoHandler(IMapper mapper, IRepository<GrupoModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(DeleteGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupo = await _repository.GetByIdAsync(request.Id);

        if (grupo == null) throw new Exception("Grupo no encontrado.");

        grupo.Eliminado = true;
        _repository.Update(grupo);

        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<bool>(true);
    }
}
