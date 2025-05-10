using GrupoModel = Domain.Entities.Forms.Grupo;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces.Shared;
using Domain.DTOs.Forms;

namespace Application.Features.Forms.Grupo.Commands;

public class UpdateGrupoCommand : ICommand<Response<bool>>
{
    public required GrupoDTO GrupoDTO { get; set; }
}

public class UpdateGrupoHandler : ICommandHandler<UpdateGrupoCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<GrupoModel> _repository;

    public UpdateGrupoHandler(IMapper mapper, IRepository<GrupoModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(UpdateGrupoCommand request, CancellationToken cancellationToken)
    {
        var grupo = await _repository.GetByIdAsync(request.GrupoDTO.Id);

        if (grupo == null) throw new Exception("Grupo no encontrada.");

        _mapper.Map(request.GrupoDTO, grupo);

        _repository.Update(grupo, true);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<bool>(true);
    }
}
