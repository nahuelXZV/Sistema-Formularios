using EntidadModel = Domain.Entities.Configuration.Entidad;
using AutoMapper;
using Domain.Interfaces.Shared;
using Domain.Common;
using Domain.DTOs.Configuration;

namespace Application.Features.Configuration.Entidad.Commands;

public class UpdateEntidadCommand : ICommand<Response<long>>
{
    public required EntidadDTO EntidadDTO { get; set; }
}

public class UpdateEntidadHandler : ICommandHandler<UpdateEntidadCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<EntidadModel> _repository;

    public UpdateEntidadHandler(IMapper mapper, IRepository<EntidadModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(UpdateEntidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await _repository.GetByIdAsync(request.EntidadDTO.Id);

        if (entidad == null) throw new Exception("Entidad no encontrada.");

        _mapper.Map(request.EntidadDTO, entidad);

        _repository.Update(entidad);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(entidad.Id);
    }
}
