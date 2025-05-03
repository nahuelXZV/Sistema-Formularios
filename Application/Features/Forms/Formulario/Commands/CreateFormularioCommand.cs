using FormularioModel = Domain.Entities.Forms.Formulario;
using AutoMapper;
using Domain.Common;
using Domain.DTOs.Forms;
using Domain.Interfaces.Shared;

namespace Application.Features.Forms.Formulario.Commands;

public class CreateFormularioCommand : ICommand<Response<long>>
{
    public required FormularioDTO FormularioDTO { get; set; }
}

public class CreateFormularioHandler : ICommandHandler<CreateFormularioCommand, Response<long>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<FormularioModel> _repository;

    public CreateFormularioHandler(IMapper mapper, IRepository<FormularioModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<long>> Handle(CreateFormularioCommand request, CancellationToken cancellationToken)
    {
        var gestion = _mapper.Map<FormularioModel>(request.FormularioDTO);

        gestion = await _repository.AddAsync(gestion);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new Response<long>(gestion.Id);
    }
}