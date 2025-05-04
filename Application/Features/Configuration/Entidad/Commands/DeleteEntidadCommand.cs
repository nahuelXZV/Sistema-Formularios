using EntidadModel = Domain.Entities.Configuration.Entidad;
using Domain.Common;
using Domain.Interfaces.Shared;

namespace Application.Features.Configuration.Entidad.Commands;

public class DeleteEntidadCommand : ICommand<Response<bool>>
{
    public required long Id { get; set; }
}

public class DeleteEntidadHandler : ICommandHandler<DeleteEntidadCommand, Response<bool>>
{
    private readonly IRepository<EntidadModel> _repository;

    public DeleteEntidadHandler(IRepository<EntidadModel> repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(DeleteEntidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await _repository.GetByIdAsync(request.Id);

        if (entidad == null) throw new Exception("Entidad no encontrada.");

        entidad.Eliminado = true;

        _repository.Update(entidad);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<bool>(true);
    }
}
