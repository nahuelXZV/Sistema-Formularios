using Domain.DTOs.Configuration;
using FluentValidation;

namespace WebClient.Common.Validators.Configuration;

public class CreateEntidadDTOValidator : AbstractValidator<EntidadDTO>
{
    public CreateEntidadDTOValidator()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.Correo)
            .EmailAddress().WithMessage("El formato del correo no es válido.")
            .When(p => !string.IsNullOrWhiteSpace(p.Correo));
    }
}