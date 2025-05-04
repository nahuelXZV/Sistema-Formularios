using Domain.DTOs.Forms;
using FluentValidation;

namespace WebClient.Common.Validators.Forms;

public class CreateGestionDTOValidator : AbstractValidator<GestionDTO>
{
    public CreateGestionDTOValidator()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.FechaInicio)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .LessThanOrEqualTo(p => p.FechaFin).WithMessage("{PropertyName} debe ser menor o igual a la fecha de fin.");

        RuleFor(p => p.FechaFin)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .GreaterThanOrEqualTo(p => p.FechaInicio).WithMessage("{PropertyName} debe ser mayor o igual a la fecha de inicio.");
    }
}