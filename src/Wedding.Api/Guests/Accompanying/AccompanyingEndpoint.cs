using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Guests.Accompanying;

public static class AccompanyingEndpoint
{
    public static async Task<Ok<IEnumerable<GuestResponseModel>>> Handler(Guid id, [FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new ListAccompanyingGuestsQuery(id));
        return TypedResults.Ok(results);
    }
}
