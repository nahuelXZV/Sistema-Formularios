using Domain.DTOs.Forms;
using FluentValidation;

namespace WebClient.Common.Validators.Forms;

public class CreatePreguntaDTOValidator : AbstractValidator<PreguntaDTO>
{
    public CreatePreguntaDTOValidator()
    {
        RuleFor(p => p.Enunciado)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.Orden)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull();

        RuleFor(p => p.Ponderacion)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull();

        RuleFor(p => p.TipoId)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull();
    }
}