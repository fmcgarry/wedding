using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Core.Exceptions;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Commands;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Features;

public class Guests : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/guests").WithTags("Guests");

        group
            .MapGet("/", async ([FromServices] IMediator mediator) =>
            {
                var results = await mediator.Send(new ListGuestsQuery());
                return TypedResults.Ok(results);
            })
            .WithMetadata(new SwaggerOperationAttribute("Lists all guests"));

        group
            .MapPost("/", async ([FromBody] GuestModel guest, [FromServices] IMediator mediator) =>
            {
                Guid id = await mediator.Send(new AddGuestCommand(guest.Name, guest.Email));
                return TypedResults.Created(id.ToString(), guest);
            })
            .WithMetadata(new SwaggerOperationAttribute("Adds a new guest"));

        group
            .MapGet("/{id:Guid}", async Task<Results<Ok<GuestModel>, NotFound>> (Guid id, [FromServices] IMediator mediator) =>
            {
                try
                {
                    var result = await mediator.Send(new GetGuestbyIdQuery(id));
                    return TypedResults.Ok(result);
                }
                catch (GuestNotFoundException)
                {
                    return TypedResults.NotFound();
                }
            })
            .WithMetadata(new SwaggerOperationAttribute("Gets a specific guest"));

        group
            .MapPut("/{id:Guid}", async Task<Results<NoContent, NotFound>> (Guid id, [FromBody] GuestModel guest, [FromServices] IMediator mediator) =>
            {
                try
                {
                    await mediator.Send(new UpdateGuestInfoCommand(id, guest));
                    return TypedResults.NoContent();
                }
                catch (GuestNotFoundException)
                {
                    return TypedResults.NotFound();
                }
            })
            .WithMetadata(new SwaggerOperationAttribute("Updates a specific guest"));

        group
            .MapDelete("/{id:Guid}", async (Guid id, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(new RemoveGuestCommand(id));
                return Results.NoContent();
            })
            .WithMetadata(new SwaggerOperationAttribute("Deletes a specific guest"));
    }
}