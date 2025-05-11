using RespuestaGrupoModel = Domain.Entities.Forms.RespuestaGrupo;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.RespuestaGrupo.Command;

public class CreateRespuestaGrupoCommand : ICommand<Response<long>>
{
    public required RespuestaGrupoDTO RespuestaGrupoDTO { get; set; }
}

public class CreateRespuestaGrupoHandler : ICommandHandler<CreateRespuestaGrupoCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<RespuestaGrupoModel> _repository;

    public CreateRespuestaGrupoHandler(IMapper mapper, IRepository<RespuestaGrupoModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(CreateRespuestaGrupoCommand request, CancellationToken cancellationToken)
    {
        var respuesta = _mapper.Map<RespuestaGrupoModel>(request.RespuestaGrupoDTO);

        respuesta = await _repository.AddAsync(respuesta);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(respuesta.Id);
    }
}