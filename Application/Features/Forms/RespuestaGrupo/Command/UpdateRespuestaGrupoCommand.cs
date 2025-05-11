using RespuestaGrupoModel = Domain.Entities.Forms.RespuestaGrupo;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.RespuestaGrupo.Command;

public class UpdateRespuestaGrupoCommand : ICommand<Response<bool>>
{
    public required RespuestaGrupoDTO RespuestaGrupoDTO { get; set; }
}

public class UpdateRespuestaGrupoHandler : ICommandHandler<UpdateRespuestaGrupoCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<RespuestaGrupoModel> _repository;

    public UpdateRespuestaGrupoHandler(IMapper mapper, IRepository<RespuestaGrupoModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(UpdateRespuestaGrupoCommand request, CancellationToken cancellationToken)
    {
        var respuesta = await _repository.GetByIdAsync(request.RespuestaGrupoDTO.Id);

        if (respuesta == null) throw new Exception("Respuesta no encontrada.");

        _mapper.Map(request.RespuestaGrupoDTO, respuesta);

        _repository.Update(respuesta);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<bool>(true);
    }
}