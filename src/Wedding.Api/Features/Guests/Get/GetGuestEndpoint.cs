using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Exceptions;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Features.Guests.Get;

public static class GetGuestEndpoint
{
    public const string Route = "/{id:guid}";
    public const string Description = "Gets a specific guest";

    public static async Task<Results<Ok<GuestModel>, NotFound>> Handler(Guid id, [FromServices] IMediator mediator)
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
}