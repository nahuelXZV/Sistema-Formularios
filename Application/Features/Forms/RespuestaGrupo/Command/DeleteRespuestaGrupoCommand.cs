using RespuestaGrupoModel = Domain.Entities.Forms.RespuestaGrupo;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces.Shared;
namespace Application.Features.Forms.RespuestaGrupo.Command;

public class DeleteRespuestaGrupoCommand : ICommand<Response<bool>>
{
    public required long Id { get; set; }
}

public class DeleteRespuestaGrupoHandler : ICommandHandler<DeleteRespuestaGrupoCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<RespuestaGrupoModel> _repository;

    public DeleteRespuestaGrupoHandler(IMapper mapper, IRepository<RespuestaGrupoModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(DeleteRespuestaGrupoCommand request, CancellationToken cancellationToken)
    {
        var respuesta = await _repository.GetByIdAsync(request.Id);

        if (respuesta == null) throw new Exception("Respuesta no encontrada.");

        respuesta.Eliminado = true;

        _repository.Update(respuesta);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<bool>(true);
    }
}