using FluentValidation;

namespace CleanArchitecture.Aplication.Features.Directors.Commands.CreateDirector
{
    public class CreateCommanValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateCommanValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(p => p.Apellido)
                .NotNull().WithMessage("{Apellido} no puede ser nulo");
        }
    }
}
