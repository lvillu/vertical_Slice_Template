

using Application.Domain.Entities;
using Application.Domain.Response;
using Application.Infrastructure;
using FluentValidation;
using MediatR;

namespace Application.Features.Personas.Commands
{
  public class CreatePersonaCommand : IRequest<DataResponse<Persona>>
  {
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public bool Active { get; set; }
  }


  public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, DataResponse<Persona>>
  {
    private readonly ApplicationDbContext _context;
    private readonly IValidator<CreatePersonaCommand> _validator;


    public CreatePersonaCommandHandler(ApplicationDbContext context, IValidator<CreatePersonaCommand> validator)
    {
      _context = context;
      _validator = validator;
    }
    public async Task<DataResponse<Persona>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
    {
      // Validar el comando antes de procesarlo
      var validationResult = await _validator.ValidateAsync(request, cancellationToken);
      if (!validationResult.IsValid)
      {
        // Si hay errores de validación, crear y devolver un DataResponse con el mensaje de error
        return new DataResponse<Persona>
        {
          success = false,
          message = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
        };
      }

      var persona = new Persona { Name = request.Name, LastName = request.LastName, Age = request.Age };


      _context.Personas.Add(persona);
      await _context.SaveChangesAsync(cancellationToken);

      return new DataResponse<Persona>
      {
        success = true,
        data = persona,
        message = "Persona creada exitosamente."
      };

    }
  }

  public class CreatePersonaCommandValidator : AbstractValidator<CreatePersonaCommand>
  {
    public CreatePersonaCommandValidator()
    {

      RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es requerido");
      RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es requerido");
      RuleFor(x => x.Age).GreaterThan(0).WithMessage("La edad debe ser mayor a 0");
    }
  }

}
