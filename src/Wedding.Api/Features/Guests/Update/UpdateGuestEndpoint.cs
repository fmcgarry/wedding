using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Exceptions;
using Wedding.UseCases.Guests.Commands;

namespace Wedding.Api.Features.Guests.Update;

public static class UpdateGuestEndpoint
{
    public const string Route = "/{id:guid}";
    public const string Description = "Updates a specific guest";

    public static async Task<Results<NoContent, NotFound>> Handler(Guid id, [FromBody] AddGuestCommand model, [FromServices] IMediator mediator)
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
}