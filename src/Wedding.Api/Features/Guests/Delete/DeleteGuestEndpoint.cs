using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Guests.Commands;

namespace Wedding.Api.Features.Guests.Delete;

public static class DeleteGuestEndpoint
{
    public const string Route = "/{id:guid}";
    public const string Description = "Deletes a specific guest";

    public static async Task<NoContent> Handler(Guid id, [FromServices] IMediator mediator)
    {
        await mediator.Send(new RemoveGuestCommand(id));
        return TypedResults.NoContent();
    }
}