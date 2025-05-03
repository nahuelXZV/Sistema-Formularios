using GestionModel = Domain.Entities.Forms.Gestion;
using Domain.Common;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.Gestion.Commands;

public class DeleteGestionCommand : ICommand<Response<long>>
{
    public required long Id { get; set; }
}

public class DeleteGestionHandler : ICommandHandler<DeleteGestionCommand, Response<long>>
{
    private readonly IRepository<GestionModel> _repository;

    public DeleteGestionHandler(IRepository<GestionModel> repository)
    {
        _repository = repository;
    }

    public async Task<Response<long>> Handle(DeleteGestionCommand request, CancellationToken cancellationToken)
    {
        var gestion = await _repository.GetByIdAsync(request.Id);

        if (gestion == null) throw new Exception("Gestion no encontrado.");

        gestion.Eliminado = true;

        _repository.Update(gestion);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(gestion.Id);
    }
}
