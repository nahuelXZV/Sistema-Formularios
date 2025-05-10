using FluentValidation;

namespace Application.Features.Forms.Grupo.Commands.Validators;

public class CreateGrupoCommandValidator : AbstractValidator<CreateGrupoCommand>
{
    public CreateGrupoCommandValidator()
    {
        RuleFor(p => p.GrupoDTO.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.GrupoDTO.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");
    }
}