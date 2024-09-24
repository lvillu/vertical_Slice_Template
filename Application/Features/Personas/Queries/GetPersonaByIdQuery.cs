using Application.Domain.Entities;
using Application.Domain.Response;
using Application.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Personas.Queries
{
    public class GetPersonaByIdQuery : IRequest<DataResponse<Persona>>
  {
        public int Id { get; set; }
  }

  public class GetPersonaByIdQueryHandler : IRequestHandler<GetPersonaByIdQuery, DataResponse<Persona>>
  {

    private readonly ApplicationDbContext _context;

    public GetPersonaByIdQueryHandler(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<DataResponse<Persona>> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
    {
      DataResponse<Persona> response = new DataResponse<Persona>();

      Persona? persona = await _context.Personas
          .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

      if (persona == null)
      {
        response.message = "No se encontraron personas";
      }
      else
      {
        response.data = persona;
      }

      return response;
    }
  }

}
