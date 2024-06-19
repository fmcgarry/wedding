using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Exceptions;
using Wedding.UseCases.Guests.Commands;

namespace Wedding.Api.Features.Guests.Rsvp;

public static class RsvpEndpoint
{
    public const string Route = "/{id:guid}/rsvp";
    public const string Description = "Sets a guest as attending";

    public static async Task<Results<Ok, NotFound>> Handler(Guid id, [FromBody] RsvpDTO rsvp, [FromServices] IMediator mediator)
    {
        try
        {
            await mediator.Send(new RsvpCommand(id, rsvp.DinnerSelection));
            return TypedResults.Ok();
        }
        catch (GuestNotFoundException)
        {
            return TypedResults.NotFound();
        }
    }
}
