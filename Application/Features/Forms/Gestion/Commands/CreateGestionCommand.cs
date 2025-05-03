using GestionModel = Domain.Entities.Forms.Gestion;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces.Shared;
using Domain.DTOs.Forms;

namespace Application.Features.Forms.Gestion.Commands;

public class CreateGestionCommand : ICommand<Response<long>>
{
    public required GestionDTO GestionDTO { get; set; }
}

public class CreateGestionHandler : ICommandHandler<CreateGestionCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<GestionModel> _repository;

    public CreateGestionHandler(IMapper mapper, IRepository<GestionModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(CreateGestionCommand request, CancellationToken cancellationToken)
    {
        var gestion = _mapper.Map<GestionModel>(request.GestionDTO);

        gestion = await _repository.AddAsync(gestion);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(gestion.Id);
    }
}