using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.UseCases.Guests;
using Wedding.UseCases.Guests.Queries;

namespace Wedding.Api.Features.Guests.GetAll;

public static class GetAllGuestsEndpoint
{
    public const string Route = "/";
    public const string Description = "Lists all guests";

    public static async Task<Ok<IEnumerable<GuestModel>>> Handler([FromServices] IMediator mediator)
    {
        var results = await mediator.Send(new ListGuestsQuery());
        return TypedResults.Ok(results);
    }
}