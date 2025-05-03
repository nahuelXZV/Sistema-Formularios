using FormularioModel = Domain.Entities.Forms.Formulario;
using Domain.Common;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.Formulario.Commands;

public class DeleteFormularioCommand : ICommand<Response<long>>
{
    public required long Id { get; set; }
}

public class DeleteFormularioHandler : ICommandHandler<DeleteFormularioCommand, Response<long>>
{
    private readonly IRepository<FormularioModel> _repository;

    public DeleteFormularioHandler(IRepository<FormularioModel> repository)
    {
        _repository = repository;
    }

    public async Task<Response<long>> Handle(DeleteFormularioCommand request, CancellationToken cancellationToken)
    {
        var formulario = await _repository.GetByIdAsync(request.Id);

        if (formulario == null) throw new Exception("Formulario no encontrado.");

        formulario.Eliminado = true;

        _repository.Update(formulario);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(formulario.Id);
    }
}
