using FluentValidation;

namespace Application.Features.Forms.Formulario.Commands.Validators;

public class CreateFormularioCommandValidator : AbstractValidator<CreateFormularioCommand>
{
    public CreateFormularioCommandValidator()
    {
        RuleFor(p => p.FormularioDTO.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.FormularioDTO.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.FormularioDTO.ListaPreguntas)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .Must(p => p.Count > 0).WithMessage("{PropertyName} no debe estar vacio.");

    }
}