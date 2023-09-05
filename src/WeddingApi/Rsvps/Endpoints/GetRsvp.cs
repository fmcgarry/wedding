using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Rsvps.Dtos;

namespace WeddingApi.Rsvps.Endpoints;

public static class GetRsvp
{
    public static async Task<Results<NotFound, Ok<RsvpDTO>>> Handler([FromRoute] Guid id, [FromServices] IRsvpService rsvpService)
    {
        var rsvp = await rsvpService.GetRsvpByIdAsync(id);
        if (rsvp is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new RsvpDTO()
        {

        });
    }
}
