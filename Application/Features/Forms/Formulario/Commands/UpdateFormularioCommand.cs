using FormularioModel = Domain.Entities.Forms.Formulario;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.Formulario.Commands;

public class UpdateFormularioCommand : ICommand<Response<bool>>
{
    public required FormularioDTO FormularioDTO { get; set; }
}

public class UpdateFormularioHandler : ICommandHandler<UpdateFormularioCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<FormularioModel> _repository;

    public UpdateFormularioHandler(IMapper mapper, IRepository<FormularioModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(UpdateFormularioCommand request, CancellationToken cancellationToken)
    {
        var formulario = await _repository.GetByIdAsync(request.FormularioDTO.Id);

        if (formulario == null) throw new Exception("Formulario no encontrado.");

        _mapper.Map(request.FormularioDTO, formulario);

        _repository.Update(formulario, true);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<bool>(true);
    }
}
