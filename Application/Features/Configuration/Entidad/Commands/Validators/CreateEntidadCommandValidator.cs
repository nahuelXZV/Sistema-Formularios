using FluentValidation;

namespace Application.Features.Configuration.Entidad.Commands.Validators;

public class CreateEntidadCommandValidator : AbstractValidator<CreateEntidadCommand>
{
    public CreateEntidadCommandValidator()
    {
        RuleFor(p => p.EntidadDTO.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.EntidadDTO.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");
    }
}