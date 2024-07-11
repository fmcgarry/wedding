using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Features.Guests.Accompanying;

public static class AccompanyingEndpoint
{
    public const string Route = "/{id:guid}/accompanying";
    public const string Description = "Lists all accompanying guests a guest has invited";

    public static async Task<Ok<IEnumerable<GuestModel>>> Handler(Guid id, [FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new ListAccompanyingGuestsQuery(id));
        return TypedResults.Ok(results);
    }
}