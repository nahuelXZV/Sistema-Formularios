using GestionModel = Domain.Entities.Forms.Gestion;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces.Shared;
using Domain.DTOs.Forms;

namespace Application.Features.Forms.Gestion.Commands;

public class UpdateGestionCommand : ICommand<Response<long>>
{
    public required GestionDTO GestionDTO { get; set; }
}

public class UpdateGestionHandler : ICommandHandler<UpdateGestionCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<GestionModel> _repository;

    public UpdateGestionHandler(IMapper mapper, IRepository<GestionModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(UpdateGestionCommand request, CancellationToken cancellationToken)
    {
        var gestion = await _repository.GetByIdAsync(request.GestionDTO.Id);

        if (gestion == null) throw new Exception("Gestion no encontrado.");

        _mapper.Map(request.GestionDTO, gestion);
        _repository.Update(gestion);

        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(gestion.Id);
    }
}
