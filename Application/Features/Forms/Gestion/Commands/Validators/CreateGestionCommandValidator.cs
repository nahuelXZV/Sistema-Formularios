using FluentValidation;

namespace Application.Features.Forms.Gestion.Commands.Validators;

public class CreateGestionCommandValidator : AbstractValidator<CreateGestionCommand>
{
    public CreateGestionCommandValidator()
    {
        RuleFor(p => p.GestionDTO.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.GestionDTO.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.GestionDTO.FechaInicio)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .LessThanOrEqualTo(p => p.GestionDTO.FechaFin).WithMessage("{PropertyName} debe ser menor o igual a la fecha de fin.");

        RuleFor(p => p.GestionDTO.FechaFin)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .GreaterThanOrEqualTo(p => p.GestionDTO.FechaInicio).WithMessage("{PropertyName} debe ser mayor o igual a la fecha de inicio.");
    }
}