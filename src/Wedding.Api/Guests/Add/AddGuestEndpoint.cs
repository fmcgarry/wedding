using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Commands;

namespace Wedding.Api.Guests.Add;

public static class AddGuestEndpoint
{
    public const string Route = "/";
    public const string Description = "Add a new guest";

    public static async Task<Created<GuestModel>> Handler([FromBody] GuestModel guest, [FromServices] IMediator mediator)
    {
        var response = await mediator.Send(new AddGuestCommand(guest));
        return TypedResults.Created($"{response}", guest);
    }
}