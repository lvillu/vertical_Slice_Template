using Application.Features.Personas.Commands;
using FluentValidation;

namespace Application.Features.Personas.Validators
{
  public class CreatePersonaValidator : AbstractValidator<CreatePersonaCommand>
  {
    public CreatePersonaValidator() {

      RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es requerido");
      RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es requerido");
      RuleFor(x => x.Age).GreaterThan(0).WithMessage("La edad debe ser mayor a 0");
    }
  }
}
