using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Guests.Exceptions;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Commands;

namespace Wedding.Api.Guests.Update;

public static class UpdateGuestEndpoint
{
    public const string Route = "/{id:guid}";
    public const string Description = "Updates a specific guest";

    public static async Task<Results<NoContent, NotFound>> Handler(Guid id, [FromBody] GuestModel guest, [FromServices] IMediator mediator)
    {
        try
        {
            await mediator.Send(new UpdateGuestCommand(id, guest.Name, guest.Email));
            return TypedResults.NoContent();
        }
        catch (GuestNotFoundException)
        {
            return TypedResults.NotFound();
        }
    }
}