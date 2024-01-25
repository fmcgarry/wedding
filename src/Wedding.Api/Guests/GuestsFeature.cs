using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Wedding.Api.Guests.Accompanying;
using Wedding.Api.Guests.Rsvp;
using Wedding.Core.Exceptions;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Commands;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Guests;

public class GuestsFeature : IFeature
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/guests").WithTags("Guests");

        group.MapGet("/", GetAllGuestsEndpoint)
            .WithMetadata(new SwaggerOperationAttribute("Lists all guests"));

        group.MapPost("/", AddGuestEndpoint)
            .WithMetadata(new SwaggerOperationAttribute("Adds a new guest"));

        group.MapPut("/{id:guid}", UpdateGuestEndpoint)
            .WithMetadata(new SwaggerOperationAttribute("Updates a specific guest"));

        group.MapGet("/{id:guid}", GetGuestEndpoint)
            .WithMetadata(new SwaggerOperationAttribute("Gets a specific guest"));

        group.MapDelete("/{id:guid}", DeleteGuestEndpoint)
            .WithMetadata(new SwaggerOperationAttribute("Deletes a specific guest"));

        group.MapPost("/{id:guid}/rsvp", RsvpEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Sets a guest as attending"));

        group.MapGet("/{id:guid}/accompanying", AccompanyingEndpoint.Handler)
            .WithMetadata(new SwaggerOperationAttribute("Lists all accompanying guests a guest has invited"));
    }

    private static async Task<Created<AddGuestCommand>> AddGuestEndpoint([FromBody] AddGuestCommand command, [FromServices] IMediator mediator)
    {
        var response = await mediator.Send(command);
        return TypedResults.Created($"{response}", command);
    }

    private static async Task<Ok<IEnumerable<GuestResponseModel>>> GetAllGuestsEndpoint([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new ListGuestsQuery());
        return TypedResults.Ok(results);
    }

    private static async Task<Results<Ok<GuestResponseModel>, NotFound>> GetGuestEndpoint(Guid id, [FromServices] IMediator mediator)
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
    }

    private static async Task<Results<NoContent, NotFound>> UpdateGuestEndpoint(Guid id, [FromBody] AddGuestCommand model, [FromServices] IMediator mediator)
    {
        try
        {
            await mediator.Send(new UpdateGuestCommand(id, model.Name, model.Email));
            return TypedResults.NoContent();
        }
        catch (GuestNotFoundException)
        {
            return TypedResults.NotFound();
        }
    }

    private static async Task<NoContent> DeleteGuestEndpoint(Guid id, [FromServices] IMediator mediator)
    {
        await mediator.Send(new RemoveGuestCommand(id));
        return TypedResults.NoContent();
    }
}