using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Commands;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Features;

public class Guests : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/guests").WithTags("Guests");

        group.MapGet("/", async ([FromServices] IMediator mediator) =>
        {
            var results = await mediator.Send(new ListGuestsQuery());
            return TypedResults.Ok(results);
        }).WithMetadata(new SwaggerOperationAttribute("Gets all guests"));

        group.MapPost("/", async ([FromBody] GuestModel guest, [FromServices] IMediator mediator) =>
        {
            await mediator.Send(new AddGuestCommand(guest.Name, guest.Email));
            return TypedResults.CreatedAtRoute(guest);
        }).WithMetadata(new SwaggerOperationAttribute("Adds a guest"));

        group.MapGet("/{id:Guid}", async (Guid id, [FromServices] IMediator mediator) =>
        {
            var result = await mediator.Send(new GetGuestbyIdQuery(id));
            return TypedResults.Ok(result);
        }).WithMetadata(new SwaggerOperationAttribute("Gets a single guest by id"));

        group.MapPut("/{id:Guid}", async (Guid id, [FromBody] GuestModel guest, [FromServices] IMediator mediator) =>
        {
            await mediator.Send(new UpdateGuestCommand(id, guest));
            return Results.NoContent();
        }).WithMetadata(new SwaggerOperationAttribute("Updates a guest by id"));

        group.MapDelete("/{id:Guid}", async (Guid id, [FromServices] IMediator mediator) =>
        {
            await mediator.Send(new RemoveGuestCommand(id));
            return Results.NoContent();
        }).WithMetadata(new SwaggerOperationAttribute("Deletes a guest by id"));
    }
}
