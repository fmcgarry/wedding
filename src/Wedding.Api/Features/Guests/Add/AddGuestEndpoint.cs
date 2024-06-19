using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Guests.Commands;

namespace Wedding.Api.Features.Guests.Add;

public static class AddGuestEndpoint
{
    public const string Route = "/";
    public const string Description = "Add a new guest";

    public static async Task<Created<AddGuestCommand>> Handler([FromBody] AddGuestCommand command, [FromServices] IMediator mediator)
    {
        var response = await mediator.Send(command);
        return TypedResults.Created($"{response}", command);
    }
}