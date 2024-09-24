

using Application.Domain.Entities;
using Application.Infrastructure;
using MediatR;

namespace Application.Features.Personas.Commands
{
  public class CreatePersonaCommand : IRequest<int>
  {
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public bool Active { get; set; }
  }


  public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, int>
  {
    private readonly ApplicationDbContext _context;

    public CreatePersonaCommandHandler(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<int> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
    {
      var persona = new Persona { Name = request.Name, LastName = request.LastName, Age = request.Age };


      _context.Personas.Add(persona);
      await _context.SaveChangesAsync();

      return persona.Id;
      
    }
  }

}
