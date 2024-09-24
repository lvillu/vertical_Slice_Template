using Application.Features.Personas.Commands;
using Application.Features.Personas.Queries;
using Carter;
using MediatR;

namespace Api.Routes
{
  public class PersonaModule : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {

      // Obtener persona por ID
      app.MapGet("/api/personas/{id:int}", async (IMediator mediator, int id) =>
      {
        var result = await mediator.Send(new GetPersonaByIdQuery { Id = id });
        return result is not null ? Results.Ok(result) : Results.NotFound();
      });

      app.MapPost("api/persona", async (IMediator mediator, CreatePersonaCommand command) =>
      {
        var results = await mediator.Send(command);
        return Results.Ok(results);
      });

    }
  }
}
