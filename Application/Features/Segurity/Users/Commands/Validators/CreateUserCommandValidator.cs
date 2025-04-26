using FluentValidation;

namespace Application.Features.Segurity.Users.Commands.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.UsuarioDTO.Username)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.UsuarioDTO.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.UsuarioDTO.Apellido)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} no debe exceder los 250 caracteres.");

        RuleFor(p => p.UsuarioDTO.Email)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull()
            .EmailAddress().WithMessage("{PropertyName} no es un email válido.")
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

        RuleFor(p => p.UsuarioDTO.Password)
            .NotEmpty().WithMessage("{PropertyName} es requerido.")
            .NotNull();

        RuleFor(p => p.UsuarioDTO.PerfilId)
             .NotEmpty().WithMessage("{PropertyName} es requerido.")
             .NotNull();
    }
}

