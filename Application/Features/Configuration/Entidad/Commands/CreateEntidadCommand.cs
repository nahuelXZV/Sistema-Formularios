using EntidadModel = Domain.Entities.Configuration.Entidad;
using AutoMapper;
using Domain.Interfaces.Shared;
using Domain.Common;
using Domain.DTOs.Configuration;

namespace Application.Features.Configuration.Entidad.Commands;

public class CreateEntidadCommand : ICommand<Response<long>>
{
    public required EntidadDTO EntidadDTO { get; set; }
}

public class CreateEntidadHandler : ICommandHandler<CreateEntidadCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<EntidadModel> _repository;

    public CreateEntidadHandler(IMapper mapper, IRepository<EntidadModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(CreateEntidadCommand request, CancellationToken cancellationToken)
    {
        var gestion = _mapper.Map<EntidadModel>(request.EntidadDTO);

        gestion = await _repository.AddAsync(gestion);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(gestion.Id);
    }
}